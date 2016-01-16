namespace Exira.StaticMailer

module internal Configuration =
    open System.IO
    open System.Reflection
    open FSharp.Configuration

    let private entryAssembly = Assembly.GetEntryAssembly()
    let private executablePath = entryAssembly.Location |> Path.GetDirectoryName
    let private configPath = Path.Combine(executablePath, "Mailer.yaml")

    type MailerConfig = YamlConfig<"Mailer.yaml">
    let mailerConfig = MailerConfig()
    mailerConfig.LoadAndWatch configPath |> ignore
