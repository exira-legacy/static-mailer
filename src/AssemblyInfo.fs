namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.0.15")>]
[<assembly: AssemblyFileVersionAttribute("1.0.15")>]
[<assembly: AssemblyMetadataAttribute("githash","e5b7e31272bf6b3137e915bdb4e2d760c3db8481")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0.15"
