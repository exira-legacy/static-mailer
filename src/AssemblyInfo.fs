namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("static-mailer")>]
[<assembly: AssemblyProductAttribute("Exira.StaticMailer")>]
[<assembly: AssemblyDescriptionAttribute("Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail")>]
[<assembly: AssemblyVersionAttribute("0.1.6")>]
[<assembly: AssemblyFileVersionAttribute("0.1.6")>]
[<assembly: AssemblyMetadataAttribute("githash","3533d3fadf0169fe1f0fc731edd8c23483d5546c")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.6"
