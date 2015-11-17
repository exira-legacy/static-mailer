namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.3")>]
[<assembly: AssemblyFileVersionAttribute("0.1.3")>]
[<assembly: AssemblyMetadataAttribute("githash","185087b71becf53b12560c4575aac00dd9f24b8e")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.3"
