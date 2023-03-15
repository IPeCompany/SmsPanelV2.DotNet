
# SMS.IR .NET SDK         
[![NuGet](https://img.shields.io/badge/nuget-v1.0.5-blue)](https://www.nuget.org/packages/IPE.SmsIr/)

Sms.ir provides a simple HTTP-based API for sending and receiving text messages.
This .Net library helps you to use the SmsIr API service more easily in your .net applications.
## [REST API Document](https://apidocs.sms.ir/)

## Installation
First of all, you need to register on the [Sms.ir](https://sms.ir/).  Then, by entering the [developer section](https://app.sms.ir/developer/list), you can pick your api-key and use this package easily.

The best and easiest way to add the SmsIr library to your .NET project is to use the Nuget package manager.

### With Visual Studio IDE

From within Visual Studio, you can use the Nuget GUI to search for and install the IPE.SmsIR Nuget package. Or, as a shortcut, simply type the following command into the Package Manager Console:

```
Install-Package IPE.SmsIR
```

### With .NET Core Command Line Tools

If you are building with the .NET Core command line tools, then you can run the following command from within your project directory:

```
dotnet add package IPE.SmsIR
```

## Sample Usage
The examples below show how to initiate SmsIr helper class and send SMS message using the SmsIr .NET helper library:

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

var bulkSendResult = await smsIr.BulkSendAsync(95007079000006, "your text message", new string[] { "9120000000" });

var verificationSendResult = await smsIr.VerifySendAsync("9120000000", 100000, new VerifySendParameter[] { new VerifySendParameter("Code", "12345") });

```

## Getting help

If you need help installing or using the library, please let us know by supporting ticket.
If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against [this repository](https://github.com/IPeCompany/SmsPanelV2.dotNet).
