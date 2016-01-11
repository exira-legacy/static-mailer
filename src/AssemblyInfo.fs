namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.3.0")>]
[<assembly: AssemblyFileVersionAttribute("1.3.0")>]
[<assembly: AssemblyMetadataAttribute("githash","e7b98af3bd8e17ba5ad9baa809d64cf0e416c60b")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.3.0"
