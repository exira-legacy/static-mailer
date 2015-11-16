open System.Diagnostics
open System.Reflection
open System.IO
open FSharp.Configuration
open Topshelf
open Time

let executablePath = Assembly.GetEntryAssembly().Location |> Path.GetDirectoryName
let configPath = Path.Combine(executablePath, "Mailer.yaml")

type MailerConfig = YamlConfig<"Mailer.yaml">
let mailerConfig = MailerConfig()
mailerConfig.Load configPath

let stop _ =
    true

let start hostControl =
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
