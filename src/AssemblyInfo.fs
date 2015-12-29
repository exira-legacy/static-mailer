namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.2.0")>]
[<assembly: AssemblyFileVersionAttribute("1.2.0")>]
[<assembly: AssemblyMetadataAttribute("githash","306660072dce4515441096934aa65bbbf97ae382")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2.0"
