namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.10")>]
[<assembly: AssemblyFileVersionAttribute("0.1.10")>]
[<assembly: AssemblyMetadataAttribute("githash","ef8a42490820a04bd0cd448b3578b738bd69c0ac")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.10"
