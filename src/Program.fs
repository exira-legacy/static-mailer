open System.Threading
open System.Net
open System.IO
open Topshelf
open Time
open Suave.Web
open Suave.Types
open Suave.OpenSSL.Provider
open OpenSSL.Core
open OpenSSL.X509
open Mailer

let mutable cancellationTokenSource = None

let stop _ =
    match cancellationTokenSource with
    | Some (cts: CancellationTokenSource) ->
        cts.Cancel()
        cancellationTokenSource <- None
        true
    | None ->
        true

let start hostControl =
    let cts = new CancellationTokenSource()

    let httpBinding() = HttpBinding.mk HTTP (IPAddress.Parse "0.0.0.0") (uint16 mailerConfig.Mailer.Endpoint.HttpPort)
    let httpsBinding() =
        use bio = new BIO(File.ReadAllBytes mailerConfig.Mailer.Endpoint.HttpsPfx)
        let cert = X509Certificate.FromPKCS12(bio, mailerConfig.Mailer.Endpoint.HttpsPassword)
        HttpBinding.mk (HTTPS (open_ssl cert)) (IPAddress.Parse "0.0.0.0") (uint16 mailerConfig.Mailer.Endpoint.HttpsPort)

    let bindings =
        match mailerConfig.Mailer.Endpoint.UseHttp, mailerConfig.Mailer.Endpoint.UseHttps with
        | true, true -> [ httpBinding(); httpsBinding() ]
        | true, false -> [ httpBinding() ]
        | false, true -> [ httpsBinding() ]
        | false, false -> [ ]

    let webConfig =
        { defaultConfig with
            cancellationToken = cts.Token
            listenTimeout = ms mailerConfig.Mailer.Endpoint.Timeout
            bindings = bindings }

    startWebServerAsync webConfig application
    |> snd
    |> Async.StartAsTask
    |> ignore

    cancellationTokenSource <- Some cts
    true

[<EntryPoint>]
let main argv =
    Service.Default
    |> run_as_local_system
    |> start_auto
    |> enable_shutdown
    |> with_recovery (ServiceRecovery.Default |> restart (min mailerConfig.Mailer.Service.RestartIntervalInMinutes))
    |> with_start start
    |> with_stop stop
    |> description mailerConfig.Mailer.Service.Description
    |> display_name mailerConfig.Mailer.Service.ServiceName
    |> service_name mailerConfig.Mailer.Service.ServiceName
    |> run
