namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.1.19")>]
[<assembly: AssemblyFileVersionAttribute("1.1.19")>]
[<assembly: AssemblyMetadataAttribute("githash","ccb70c18842898e978d8bb68cead95b6e791519d")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.1.19"
