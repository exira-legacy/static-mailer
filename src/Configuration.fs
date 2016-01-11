namespace Exira.StaticMailer

module internal Configuration =
    open System.IO
    open System.Reflection
    open FSharp.Configuration

    let entryAssembly = Assembly.GetEntryAssembly()
    let executablePath = entryAssembly.Location |> Path.GetDirectoryName
    let configPath = Path.Combine(executablePath, "Mailer.yaml")

    type MailerConfig = YamlConfig<"Mailer.yaml">
    let mailerConfig = MailerConfig()
    mailerConfig.LoadAndWatch configPath |> ignore
