namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.2.20")>]
[<assembly: AssemblyFileVersionAttribute("1.2.20")>]
[<assembly: AssemblyMetadataAttribute("githash","3d16adab3401d5e4f7e2925e7127460c60c02966")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2.20"
