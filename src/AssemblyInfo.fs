namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.4.24")>]
[<assembly: AssemblyFileVersionAttribute("1.4.24")>]
[<assembly: AssemblyMetadataAttribute("githash","b47ef8f792a7991c1ea51bf68410a3978cc7a654")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.4.24"
