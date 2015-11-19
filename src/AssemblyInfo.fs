namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.1.16")>]
[<assembly: AssemblyFileVersionAttribute("1.1.16")>]
[<assembly: AssemblyMetadataAttribute("githash","91e1e56cdc08713885ae5b34c4e9f657f3515c88")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.1.16"
