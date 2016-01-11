namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.3.22")>]
[<assembly: AssemblyFileVersionAttribute("1.3.22")>]
[<assembly: AssemblyMetadataAttribute("githash","587d0b7de9de4efe797377228d18b94bd50fd8df")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.3.22"
