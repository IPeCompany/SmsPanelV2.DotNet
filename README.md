
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

## Usage

The examples below show how to initiate SmsIr helper class and send SMS message using the SmsIr .NET helper library.

We also provide [an ASP.NET Core sample project](https://github.com/IPeCompany/SmsPanelV2.DotNetCore.Samples) that explains each example in more detail.

* [Quick Start](#quick-start)
* [Sends](#sends)
    * [Verify Send](#verify-send)
    * [Bulk Send](#bulk-send)
    * [Like-To-Like Send](#like-to-like-send)
    * [Remove Scheduled](#remove-scheduled)
* [Get Send Reports](#get-send-reports)
    * [Get Sent Message](#get-sent-message)
    * [Get Send Live Report](#get-send-live-report)
    * [Get Send Archive Report](#get-send-archive-report)
    * [Get Sent Pack](#get-sent-pack)
    * [Get Sent Packs](#get-sent-packs)
* [Get Receive Reports](#get-receive-reports)
    * [Get Receive Live Report](#get-receive-live-report)
    * [Get Receive Archive Report](#get-receive-archive-report)
    * [Get Latest Receives](#get-latest-receives)
* [Get Account Information](#get-account-information)
    * [Get Current Credit](#get-current-credit)
    * [Get Lines](#get-lines)
* [Error Handling](#error-handling)

<br/>

### Quick Start

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

var bulkSendResult = await smsIr.BulkSendAsync(95007079000006, "your text message", new string[] { "9120000000" });

var verificationSendResult = await smsIr.VerifySendAsync("9120000000", 100000, new VerifySendParameter[] { new VerifySendParameter("Code", "12345") });
```

<br/>

### Sends

#### Verify Send

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

string mobile = "9120000000";
int templateId = 200000;
VerifySendParameter[] verifySendParameters = {
    new VerifySendParameter("NAME", "User Name"),
    new VerifySendParameter("CODE", "12345"),
};

var response = await smsIr.VerifySendAsync(mobile, templateId, verifySendParameters);

VerifySendResult sendResult = response.Data;
int messageId = sendResult.MessageId;
decimal cost = sendResult.Cost;
```

#### Bulk Send

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

long lineNumber = 95007079000006;
string messageText = "Message Text\nSMS.ir";
string[] mobiles = { "9120000000", "9120000001" };
int? sendDateTime = null; // unix time - for instance: 1704094200

var response = await smsIr.BulkSendAsync(lineNumber, messageText, mobiles, sendDateTime);

SendResult sendResult = response.Data;
Guid packId = sendResult.PackId;
int?[] messageIds = sendResult.MessageIds;
decimal cost = sendResult.Cost;
```

#### Like-To-Like Send

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

long lineNumber = 95007079000006;
string[] messageTexts =
{
    "Message Text 1\nSMS.ir",
    "Message Text 2\nSMS.ir"
};
string[] mobiles = { "9120000000", "9120000001" };
int? sendDateTime = null; // unix time - for instance: 1704094200

var response = await smsIr.LikeToLikeSendAsync(lineNumber, messageTexts, mobiles, sendDateTime);

SendResult sendResult = response.Data;
Guid packId = sendResult.PackId;
int?[] messageIds = sendResult.MessageIds;
decimal cost = sendResult.Cost;
```

#### Remove Scheduled

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

Guid packId = new Guid("86D96B0E-FD89-4C19-B303-C0B4D3874063");

var response = await smsIr.RemoveScheduledMessagesAsync(packId);

RemoveScheduledMessagesResult result = response.Data;
decimal returnedCreditCount = result.ReturnedCreditCount;
decimal smsCount = result.SmsCount;
```

<br/>

### Get Send Reports

#### Get Sent Message

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int messageId = 10000000;

var response = await smsIr.GetReportAsync(messageId);

MessageReportResult messageReport = response.Data;
int returnedMessageId = messageReport.MessageId;
long lineNumber = messageReport.LineNumber;
long mobile = messageReport.Mobile;
string messageText = messageReport.MessageText;
int sendDateTimeInUnix = messageReport.SendDateTime;
byte? deliveryState = messageReport.DeliveryState;
int? deliveryUnixTime = messageReport.DeliveryDateTime;
decimal cost = messageReport.Cost;
```

#### Get Send Live Report

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int pageNumber = 1;
int pageSize = 100; // max: 100

var response = await smsIr.GetLiveReportAsync(pageNumber, pageSize);

MessageReportResult[] messages = response.Data;
foreach (var message in messages)
{
    int messageId = message.MessageId;
    long lineNumber = message.LineNumber;
    long mobile = message.Mobile;
    string messageText = message.MessageText;
    int sendUnixTime = message.SendDateTime;
    byte? deliveryState = message.DeliveryState;
    int? deliveryUnixTime = message.DeliveryDateTime;
    decimal cost = message.Cost;
}
```

#### Get Send Archive Report

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int? fromDateUnixTime = null; // unix time - for instance: 1700598600
int? toDateUnixTime = null; // unix time - for instance: 1703190600
int pageNumber = 1;
int pageSize = 100; // max: 100

var response = await smsIr.GetArchivedReportAsync(pageNumber, pageSize, fromDateUnixTime, toDateUnixTime);

MessageReportResult[] messages = response.Data;
foreach (var message in messages)
{
    int messageId = message.MessageId;
    long lineNumber = message.LineNumber;
    long mobile = message.Mobile;
    string messageText = message.MessageText;
    int sendUnixTime = message.SendDateTime;
    byte? deliveryState = message.DeliveryState;
    int? deliveryUnixTime = message.DeliveryDateTime;
    decimal cost = message.Cost;
}
```

#### Get Sent Pack

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

Guid packId = new Guid("86D96B0E-FD89-4C19-B303-C0B4D3874063");

var response = await smsIr.GetReportAsync(packId);

MessageReportResult[] messages = response.Data;
foreach (var message in messages)
{
    int messageId = message.MessageId;
    long lineNumber = message.LineNumber;
    long mobile = message.Mobile;
    string messageText = message.MessageText;
    int sendUnixTime = message.SendDateTime;
    byte? deliveryState = message.DeliveryState;
    int? deliveryUnixTime = message.DeliveryDateTime;
    decimal cost = message.Cost;
}
```

#### Get Sent Packs

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int pageNumber = 1;
int pageSize = 100; // max: 100

var response = await smsIr.GetSendPacksAsync(pageNumber, pageSize);

PackResult[] packs = response.Data;
foreach (var pack in packs)
{
    Guid packId = pack.PackId;
    long recipientCount = pack.RecipientCount;
    int creationUnixTime = pack.CreationDateTime;
}
```

<br/>

### Get Receive Reports

#### Get Receive Live Report

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int pageNumber = 1;
int pageSize = 100; // max: 100

var response = await smsIr.GetLiveReceivesAsync(pageNumber, pageSize);

ReceivedMessageResult[] messages = response.Data;
foreach (var message in messages)
{
    long mobile = message.Mobile;
    long lineNumber = message.Number;
    string messageText = message.MessageText;
    int receivedUnixTime = message.ReceivedDateTime;
}
```

#### Get Receive Archive Report

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int? fromDateUnixTime = null; // unix time - for instance: 1700598600
int? toDateUnixTime = null; // unix time - for instance: 1703190600
int pageNumber = 1;
int pageSize = 100; // max: 100

var response = await smsIr.GetArchivedReceivesAsync(pageNumber, pageSize, fromDateUnixTime, toDateUnixTime);

ReceivedMessageResult[] messages = response.Data;
foreach (var message in messages)
{
    long mobile = message.Mobile;
    long lineNumber = message.Number;
    string messageText = message.MessageText;
    int receivedUnixTime = message.ReceivedDateTime;
}
```

#### Get Latest Receives

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

int count = 100; // max: 100

var response = await smsIr.GetLatestReceivesAsync(count);

ReceivedMessageResult[] messages = response.Data;
foreach (var message in messages)
{
    long mobile = message.Mobile;
    long lineNumber = message.Number;
    string messageText = message.MessageText;
    int receivedUnixTime = message.ReceivedDateTime;
}
```

<br/>

### Get Account Information

#### Get Current Credit

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

var response = await smsIr.GetCreditAsync();

decimal credit = response.Data;
```

#### Get Lines

```csharp
SmsIr smsIr = new SmsIr("YOUR API KEY");

var response = await smsIr.GetLinesAsync();

long[] lines = response.Data;
```

<br/>

### Error Handling

```csharp
try
{
    SmsIr smsIr = new SmsIr("YOUR API KEY");

    string mobile = "9120000000";
    int templateId = 200000;
    VerifySendParameter[] verifySendParameters = {
        new VerifySendParameter("NAME", "User Name"),
        new VerifySendParameter("CODE", "12345"),
    };

    var response = await smsIr.VerifySendAsync(mobile, templateId, verifySendParameters);

    VerifySendResult sendResult = response.Data;
    int messageId = sendResult.MessageId;
    decimal cost = sendResult.Cost;
}
catch (Exception ex) // An exception occurred, indicating that the request was not successful.
{
    // for more details on status codes: 
    // https://app.sms.ir/developer/help/statusCode

    string errorName = ex.GetType().Name;
    string errorNameDescription = errorName switch
    {
        "UnauthorizedException" => "The provided token is not valid or access is denied.",
        "LogicalException" => "Please check and correct the request parameters.",
        "TooManyRequestException" => "The request count has exceeded the allowed limit.",
        "UnexpectedException" or "InvalidOperationException" => "An unexpected error occurred on the remote server.",
        _ => "Unable to send the request due to an unspecified error.",
    };

    var errorDescription = "There is a problem with the request." +
        $"\n - Error: {errorName} - {errorNameDescription} - {ex.Message}";
}
```


## Getting help

If you need help installing or using the library, please let us know by supporting ticket.
If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against [this repository](https://github.com/IPeCompany/SmsPanelV2.dotNet).
