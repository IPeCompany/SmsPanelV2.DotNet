using IPE.SmsIrClient.Extensions;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using IPE.SmsIrClient.Routes;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPE.SmsIrClient
{
    public class SmsIr
    {
        private readonly HttpClient _httpClient;
        private const string _baseAddress = "https://api.sms.ir/v1/";

        public SmsIr(string apiKey)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };

            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<SmsIrResult<decimal>> GetCreditAsync()
        {
            return await _httpClient.GetRequestAsync<decimal>(CreditRoutes.GetCreditRoute());
        }

        public SmsIrResult<decimal> GetCredit() =>
            GetCreditAsync().GetAwaiter().GetResult();

        public async Task<SmsIrResult<long[]>> GetLinesAsync()
        {
            return await _httpClient.GetRequestAsync<long[]>(LineRoutes.GetLinesRoute());
        }

        public SmsIrResult<long[]> GetLines() =>
            GetLinesAsync().GetAwaiter().GetResult();

        public async Task<SmsIrResult<ReceivedMessageResult[]>> GetLatestReceivesAsync(int count = 100)
        {
            return await _httpClient.GetRequestAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetLatestReceivesRoute(count));
        }

        public SmsIrResult<ReceivedMessageResult[]> GetLatestReceives(int count = 100) =>
            GetLatestReceivesAsync(count).GetAwaiter().GetResult();

        public async Task<SmsIrResult<ReceivedMessageResult[]>> GetLiveReceivesAsync(int pageNumber = 1, int pageSize = 100)
        {
            return await _httpClient.GetRequestAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetLiveReceivesRoute(pageNumber, pageSize));
        }

        public SmsIrResult<ReceivedMessageResult[]> GetLiveReceives(int pageNumber = 1, int pageSize = 100) =>
            GetLiveReceivesAsync(pageNumber, pageSize).GetAwaiter().GetResult();

        public async Task<SmsIrResult<ReceivedMessageResult[]>> GetArchivedReceivesAsync(int pageNumber = 1, int pageSize = 100, int? fromDate = null, int? toDate = null)
        {
            return await _httpClient.GetRequestAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetArchivedReceivesRoute(pageNumber, pageSize, fromDate, toDate));
        }

        public SmsIrResult<ReceivedMessageResult[]> GetArchivedReceives(int pageNumber = 1, int pageSize = 100, int? fromDate = null, int? toDate = null) =>
            GetArchivedReceivesAsync(pageNumber, pageSize, fromDate, toDate).GetAwaiter().GetResult();

        public async Task<SmsIrResult<SendResult>> BulkSendAsync(long lineNumber, string messageText, string[] mobiles, int? sendDateTime = null)
        {
            BulkSendRequest bulkSendRequest = new BulkSendRequest(lineNumber, messageText, mobiles, sendDateTime);

            return await _httpClient.PostRequestAsync<SendResult>(SendRoutes.BulkSendRoute(), bulkSendRequest);
        }

        public SmsIrResult<SendResult> BulkSend(long lineNumber, string messageText, string[] mobiles, int? sendDateTime = null) =>
            BulkSendAsync(lineNumber, messageText, mobiles, sendDateTime).GetAwaiter().GetResult();

        public async Task<SmsIrResult<SendResult>> LikeToLikeSendAsync(long lineNumber, string[] messageTexts, string[] mobiles, int? sendDateTime = null)
        {
            LikeToLikeSendRequest likeToLikeSendRequest = new LikeToLikeSendRequest(lineNumber, messageTexts, mobiles, sendDateTime);

            return await _httpClient.PostRequestAsync<SendResult>(SendRoutes.LikeToLikeSendRoute(), likeToLikeSendRequest);
        }

        public SmsIrResult<SendResult> LikeToLikeSend(long lineNumber, string[] messageTexts, string[] mobiles, int? sendDateTime = null) =>
            LikeToLikeSendAsync(lineNumber, messageTexts, mobiles, sendDateTime).GetAwaiter().GetResult();

        public async Task<SmsIrResult<RemoveScheduledMessagesResult>> RemoveScheduledMessagesAsync(Guid packId)
        {
            return await _httpClient.DeleteRequestAsync<RemoveScheduledMessagesResult>(SendRoutes.RemoveScheduledMessagesRoute(packId));
        }

        public SmsIrResult<RemoveScheduledMessagesResult> RemoveScheduledMessages(Guid packId) =>
            RemoveScheduledMessagesAsync(packId).GetAwaiter().GetResult();

        public async Task<SmsIrResult<VerifySendResult>> VerifySendAsync(string mobile, int templateId, VerifySendParameter[] parameters)
        {
            VerifySendRequest verifySendRequest = new VerifySendRequest(mobile, templateId, parameters);

            return await _httpClient.PostRequestAsync<VerifySendResult>(SendRoutes.VerifySendRoute(), verifySendRequest);
        }

        public SmsIrResult<VerifySendResult> VerifySend(string mobile, int templateId, VerifySendParameter[] parameters) =>
            VerifySendAsync(mobile, templateId, parameters).GetAwaiter().GetResult();

        public async Task<SmsIrResult<MessageReportResult>> GetReportAsync(int messageId)
        {
            return await _httpClient.GetRequestAsync<MessageReportResult>(ReportRoutes.GetSingleMessageReportRoute(messageId));
        }

        public SmsIrResult<MessageReportResult> GetReport(int messageId) =>
            GetReportAsync(messageId).GetAwaiter().GetResult();

        public async Task<SmsIrResult<MessageReportResult[]>> GetReportAsync(Guid packId)
        {
            return await _httpClient.GetRequestAsync<MessageReportResult[]>(ReportRoutes.GetPackReportRoute(packId));
        }

        public SmsIrResult<MessageReportResult[]> GetReport(Guid packId) =>
            GetReportAsync(packId).GetAwaiter().GetResult();

        public async Task<SmsIrResult<MessageReportResult[]>> GetLiveReportAsync(int pageNumber = 1, int pageSize = 100)
        {
            return await _httpClient.GetRequestAsync<MessageReportResult[]>(ReportRoutes.GetLiveReportRoute(pageNumber, pageSize));
        }

        public SmsIrResult<MessageReportResult[]> GetLiveReport(int pageNumber = 1, int pageSize = 100) =>
            GetLiveReportAsync(pageNumber, pageSize).GetAwaiter().GetResult();

        public async Task<SmsIrResult<MessageReportResult[]>> GetArchivedReportAsync(int pageNumber = 1, int pageSize = 100, int? fromDate = null, int? toDate = null)
        {
            return await _httpClient.GetRequestAsync<MessageReportResult[]>(ReportRoutes.GetArchivedReportRoute(pageNumber, pageSize, fromDate, toDate));
        }

        public SmsIrResult<MessageReportResult[]> GetArchivedReport(int pageNumber = 1, int pageSize = 100, int? fromDate = null, int? toDate = null) =>
            GetArchivedReportAsync(pageNumber, pageSize, fromDate, toDate).GetAwaiter().GetResult();

        public async Task<SmsIrResult<PackResult[]>> GetSendPacksAsync(int pageNumber = 1, int pageSize = 100)
        {
            return await _httpClient.GetRequestAsync<PackResult[]>(ReportRoutes.GetSendPacksRoute(pageNumber, pageSize));
        }

        public SmsIrResult<PackResult[]> GetSendPacks(int pageNumber = 1, int pageSize = 100) =>
            GetSendPacksAsync(pageNumber, pageSize).GetAwaiter().GetResult();
    }
}