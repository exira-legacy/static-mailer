namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("1.1.18")>]
[<assembly: AssemblyFileVersionAttribute("1.1.18")>]
[<assembly: AssemblyMetadataAttribute("githash","3f3d6c3d0eba84694978ad1add907aa779d8c13f")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.1.18"
