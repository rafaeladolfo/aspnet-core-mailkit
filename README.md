# Simple .Net Core MailKit Example

#### Simple and easy example of .net core using mailkit to send out emails.
* Place your server configuration on appsettings.json
* You can try this using a fake email program like http://nilhcem.com/FakeSMTP/ (tested with this solution)

### This is just an easy simple example

I triggered  the method that will send the message inside the controller.
`
    _emailService.Send(message);    
`

That's just to have a quick way to show how to send emails.
You could easily build a service to listen to a queue or to check a table of mail messages to send.
