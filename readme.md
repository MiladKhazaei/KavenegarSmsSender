# Kavenegar Usage App

![AspNetCore](https://img.shields.io/badge/AspNetCore-5C2D91?style=flat&logo=dotnet)

## Overview
Many developers encounter issue due to configure and send SMS to their end-users in their projects. In this repository, we develop and demonstrate the `KavenegarSMS` to send `public` or by `pattern SMS` to end-users.

### Steps:

1. We define `ISmsSener` Interface and `SmsSender` Service respectively.
2. Defines two tasks with name `SendPublic`, `SendPatternSMS` respectively into ISmsSender Interface.
3. Defines two public functions with name `SendPublic`, `SendPatternSMS` respectively into SmsSender Service.
4. Utilizing `SendPublic`, `SendPatternSMS` at `SendSmsController` to send sms to end-users.
5. Install `KavenegarDotNetCore` by: 

```powersher
Install-Package KavenegarDotNetCore
```

5. Define a KavenegarApiViewModel with requires variable for works with KavenegarApi (You can add more attributes if you want)
6. Add the following information to the `appsettings.json`:


```json
"KavenegarApi": {
  "ApiKey": "", // fills with  API key from your Kavenegar dashboard (SMS provider)
  "Sender": "", // fills with the line that you want to sends sms like 2000660110
}
```

7. Config the SmsService into the program.cs allowing ASP.NET Core knows what the services are,
8. Inject the services into the SmsService.
9. Compeleted `SendPublic` function
