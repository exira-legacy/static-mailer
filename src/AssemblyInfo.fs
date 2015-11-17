namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.8")>]
[<assembly: AssemblyFileVersionAttribute("0.1.8")>]
[<assembly: AssemblyMetadataAttribute("githash","72fdebf37bafc48ea7277ee4a6b2a758df5c3b3d")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.8"
