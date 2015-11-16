open System.Diagnostics
open System.Threading
open System.Net
open Topshelf
open Time
open Suave.Web
open Suave.Types
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

    // TODO: Add SSL from config file
    let webConfig =
        { defaultConfig with
            cancellationToken = cts.Token
            listenTimeout = ms mailerConfig.Mailer.Timeout
            bindings = [ HttpBinding.mk HTTP (IPAddress.Parse "0.0.0.0") (uint16 mailerConfig.Mailer.Port) ] }

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
    |> with_recovery (ServiceRecovery.Default |> restart (min mailerConfig.Mailer.RestartIntervalInMinutes))
    |> with_start start
    |> with_stop stop
    |> description mailerConfig.Mailer.Description
    |> display_name mailerConfig.Mailer.ServiceName
    |> service_name mailerConfig.Mailer.ServiceName
    |> run
