namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.9")>]
[<assembly: AssemblyFileVersionAttribute("0.1.9")>]
[<assembly: AssemblyMetadataAttribute("githash","82806346fc61eef0ffe0df4ea7e3429e126a135a")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.9"
