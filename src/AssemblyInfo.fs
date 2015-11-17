namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.7")>]
[<assembly: AssemblyFileVersionAttribute("0.1.7")>]
[<assembly: AssemblyMetadataAttribute("githash","d1f0a797514e343244590db650583d829f2c9cfb")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.7"
