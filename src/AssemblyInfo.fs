namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.11")>]
[<assembly: AssemblyFileVersionAttribute("0.1.11")>]
[<assembly: AssemblyMetadataAttribute("githash","b6d10919fcb518050bd1315d8d7450470ed12247")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.11"
