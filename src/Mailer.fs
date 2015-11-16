module Mailer

open System.Reflection
open System.IO
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

let greetings form =
  defaultArg (Option.ofChoice(form ^^ "name")) "World"
  |> sprintf "Hello %s"

let application =
  choose
    [ POST >>= path "/send" >>= request (fun request -> OK <| greetings request.form)
      sendStaticLogo ]