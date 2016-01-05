namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.2.21")>]
[<assembly: AssemblyFileVersionAttribute("1.2.21")>]
[<assembly: AssemblyMetadataAttribute("githash","46e4fac85bb5e37f74ea7830415e5c17c5eb9444")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2.21"
