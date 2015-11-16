module Mailer

open System.Reflection
open System.IO
open System.Net.Mail
open FSharp.Configuration
open Suave
open Suave.Types
open Suave.Web
open Suave.Http
open Suave.Http.Successful
open Suave.Http.Applicatives
open Suave.Http.Writers
open Suave.Http.Embedded
open Suave.Utils

let entryAssembly = Assembly.GetEntryAssembly()
let executablePath = entryAssembly.Location |> Path.GetDirectoryName
let configPath = Path.Combine(executablePath, "Mailer.yaml")

type MailerConfig = YamlConfig<"Mailer.yaml">
let mailerConfig = MailerConfig()
mailerConfig.Load configPath

let sendStaticLogo =
    sendResource entryAssembly "index.html" true

let buildSubject form =
    let template = mailerConfig.Mailer.Subject
    let site = defaultArg (Option.ofChoice(form ^^ "site")) "static-mailer"
    template.Replace("%SITE%", site)

let buildBody form =
    let template = mailerConfig.Mailer.Template

    let site = defaultArg (Option.ofChoice(form ^^ "site")) "static-mailer"
    let name = defaultArg (Option.ofChoice(form ^^ "name")) "N/A"
    let email = defaultArg (Option.ofChoice(form ^^ "email")) "N/A"
    let subject = defaultArg (Option.ofChoice(form ^^ "subject")) "N/A"
    let message = defaultArg (Option.ofChoice(form ^^ "message")) "N/A"

    template
        .Replace("%SITE%", site)
        .Replace("%NAME%", name)
        .Replace("%EMAIL%", email)
        .Replace("%SUBJECT%", subject)
        .Replace("%MESSAGE%", message)

let sendMail subject body =
    use mail =
        new MailMessage(
            mailerConfig.Mailer.From,
            mailerConfig.Mailer.To,
            subject,
            body,
            IsBodyHtml = true)

    use client = new SmtpClient(mailerConfig.Mailer.SmtpHost, mailerConfig.Mailer.SmtpPort)
    client.Send mail

let contact form =
    let subject = buildSubject form
    let body = buildBody form

    try
        sendMail subject body
        sprintf "success"
    with
    | ex -> sprintf "fail"

let application =
  choose
    [ POST >>= path "/send" >>= request (fun request -> OK <| contact request.form)
      sendStaticLogo ]