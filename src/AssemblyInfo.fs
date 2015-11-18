namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.12")>]
[<assembly: AssemblyFileVersionAttribute("0.1.12")>]
[<assembly: AssemblyMetadataAttribute("githash","124a16ab630f412f3be433e752fe636be4c559dc")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.12"
