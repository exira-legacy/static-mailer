namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.14")>]
[<assembly: AssemblyFileVersionAttribute("0.1.14")>]
[<assembly: AssemblyMetadataAttribute("githash","45472049ec2c10832242be56fd3658a4e280b655")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.14"
