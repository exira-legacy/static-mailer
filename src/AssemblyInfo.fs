namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.13")>]
[<assembly: AssemblyFileVersionAttribute("0.1.13")>]
[<assembly: AssemblyMetadataAttribute("githash","8ca1052c3d23d6203c06e1d29ea026a877b0ff40")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.13"
