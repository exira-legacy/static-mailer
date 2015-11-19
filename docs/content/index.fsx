(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"

(**
static-mailer [![NuGet Status](http://img.shields.io/nuget/v/Exira.StaticMailer.svg?style=flat)](https://www.nuget.org/packages/Exira.StaticMailer/)
======================

Exira.StaticMailer is a REST endpoint running in a Windows Service to enable static sites to easily send mail.

### Usage

* Download the latest release from [the GitHub releases page](https://github.com/exira/static-mailer/releases)

* Unzip somewhere

* Edit `Mailer.yaml` using:
  * UseHttp and UseHttps: `true` or `false`, if you want to listen on HTTP and/or HTTPS
  * HttpPort: `8080`, the HTTP port you want the service to listen on
  * HttpsPort: `8081`, the HTTPS port you want the service to listen on
  * HttpsPfx: `cert.pfx`, the filename of the certificate pfx file
  * HttpsPassword: `cert`, password to be used for the pfx file
  * SmtpHost: `smtp.example.org`, the SMTP server to mail
  * SmtpPort: `25`, the SMTP port to use
  * ContactDetails: A list of sites which can use the static-mailer
    * Site: `Site1`, a unique key identifying a website to send static mail for
    * From: `example@example.org`, the email address which should be shown as the sender
    * To: `site1@example.org`, the email address to send the mail to

* Run the `Install.ps1` script with the same servicename you configured in `Mailer.yaml`, for example: `powershell ./Install.ps1 -servicename static-mailer`

* Instead you can also simply run one of the following:
  * `static-mailer.exe install`
  * `static-mailer.exe start`
  * `static-mailer.exe stop`
  * `static-mailer.exe uninstall`

* Test if the service is accessibly by trying to surf to it on your configured port.

* You can now send mail from static sites by posting to `/send` with the following form fields:
  * `site`, one of the unique keys previously configured
  * `name`
  * `email`
  * `subject`
  * `message`

* If the mail has been successfully sent, you will get `success` as a response. Otherwise you will receive `fail`.

* In case of exceptions, you can view them in the Event Log

### Cloning

`git clone git@github.com:exira/static-mailer.git -c core.autocrlf=input`

### Contributing and copyright

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork
the project and submit pull requests. You might also want to read the
[library design notes][readme] to understand how it works.

For more information see the [License file][license] in the GitHub repository.

  [content]: https://github.com/exira/static-mailer/tree/master/docs/content
  [gh]: https://github.com/exira/static-mailer
  [issues]: https://github.com/exira/static-mailer/issues
  [readme]: https://github.com/exira/static-mailer/blob/master/README.md
  [license]: https://github.com/exira/static-mailer/blob/master/LICENSE.txt
*)
