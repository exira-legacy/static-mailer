namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.2.0")>]
[<assembly: AssemblyFileVersionAttribute("1.2.0")>]
[<assembly: AssemblyMetadataAttribute("githash","c9453735f69eddb6a1cff6e2ccb3467bb8f934d6")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2.0"
