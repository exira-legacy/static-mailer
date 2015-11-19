module Mailer

open System
open System.Diagnostics
open System.Reflection
open System.IO
open System.Net.Mail
open FSharp.Configuration
open Suave
open Suave.Types
open Suave.Http
open Suave.Http.Successful
open Suave.Http.RequestErrors
open Suave.Http.ServerErrors
open Suave.Http.Applicatives
open Suave.Http.Writers
open Suave.Http.Embedded
open Suave.Utils

let entryAssembly = Assembly.GetEntryAssembly()
let executablePath = entryAssembly.Location |> Path.GetDirectoryName
let configPath = Path.Combine(executablePath, "Mailer.yaml")

type MailerConfig = YamlConfig<"Mailer.yaml">
let mailerConfig = MailerConfig()
mailerConfig.LoadAndWatch configPath |> ignore

let eventLog = new EventLog()
eventLog.Log <- "Application"
eventLog.Source <- mailerConfig.Mailer.Service.ServiceName

let loadContactDetails () =
    mailerConfig.Mailer.ContactDetails
    |> Seq.map (fun x -> x.Site.ToLowerInvariant(), x)
    |> Map.ofSeq

let mutable contactDetails = loadContactDetails()

mailerConfig.Mailer.Changed.Add (fun x -> contactDetails <- loadContactDetails())

let sendStaticLogo =
    sendResource entryAssembly "index.html" true

let buildSubject form =
    let template = mailerConfig.Mailer.Subject
    let site = defaultArg (Option.ofChoice(form ^^ "site")) "N/A"
    template.Replace("%SITE%", site)

let buildBody form =
    let template = mailerConfig.Mailer.Template

    let site = defaultArg (Option.ofChoice(form ^^ "site")) "N/A"
    let name = defaultArg (Option.ofChoice(form ^^ "name")) "N/A"
    let email = defaultArg (Option.ofChoice(form ^^ "email")) "N/A"
    let subject = defaultArg (Option.ofChoice(form ^^ "subject")) "N/A"
    let message = defaultArg (Option.ofChoice(form ^^ "message")) "N/A"
    let message =
        message
            .Replace("\r\n", "<br>")
            .Replace("\n", "<br>")
            .Replace("\r", "<br>")

    template
        .Replace("%SITE%", site)
        .Replace("%NAME%", name)
        .Replace("%EMAIL%", email)
        .Replace("%SUBJECT%", subject)
        .Replace("%MESSAGE%", message)

let sendMail (contact: MailerConfig.Mailer_Type.ContactDetails_Item_Type) subject body =
    use mail =
        new MailMessage(
            contact.From,
            contact.To,
            subject,
            body,
            IsBodyHtml = true)

    use client = new SmtpClient(mailerConfig.Mailer.Smtp.SmtpHost, mailerConfig.Mailer.Smtp.SmtpPort)
    client.Send mail

let isAllowedOrigin headers =
    let origin = headers |> List.tryPick (fun (key, value) -> if key = "origin" then Some value else None)

    let findOrigin origin =
        let origin = Uri origin
        mailerConfig.Mailer.AllowedOrigins
        |> Seq.tryFind (fun uri -> uri = origin)

    let configuredOrigin =
        match origin with
        | None -> None
        | Some o -> findOrigin o

    match configuredOrigin with
    | None -> None
    | Some _ -> origin

let contact (request: HttpRequest) =
    let getContactDetails form =
        let site = defaultArg (Option.ofChoice(form ^^ "site")) "default"
        let site = site.ToLowerInvariant()
        contactDetails
        |> Map.tryFind site

    let sendToContact form contactDetails =
        let subject = buildSubject form
        let body = buildBody form

        try
            sendMail contactDetails subject body
            OK <| sprintf "success"
        with
        | ex ->
            eventLog.WriteEntry(sprintf "%s" <| ex.ToString(), EventLogEntryType.Error)
            INTERNAL_ERROR <| sprintf "fail"

    let processForm form origin =
        let contactDetails = getContactDetails form
        match contactDetails with
        | None -> BAD_REQUEST <| sprintf "fail"
        | Some c ->
            setHeader "Access-Control-Allow-Origin" origin
            >>= sendToContact form c

    let isAllowed = isAllowedOrigin request.headers
    match isAllowed with
    | None -> METHOD_NOT_ALLOWED <| sprintf "fail"
    | Some origin -> processForm request.form origin

let application =
  choose
    [ POST >>= path "/send" >>= request contact
      sendStaticLogo ]
