using System;
using System.Text;

namespace IPE.SmsIr.Routes
{
    public static class ReportRoutes
    {
        public static string GetSingleMessageReportRoute(int messageId) => $"send/{messageId}";

        public static string GetPackReportRoute(Guid packId) => $"send/pack/{packId}";

        public static string GetLiveReportRoute(int pageNumber, int pageSize) => $"send/live?pageNumber={pageNumber}&pageSize={pageSize}";

        public static string GetArchivedReportRoute(int pageNumber, int pageSize, int? fromDate, int? toDate)
        {
            StringBuilder uriBuilder = new StringBuilder($"send/archive?pageNumber={pageNumber}&pageSize={pageSize}");

            if (fromDate.HasValue)
                uriBuilder.Append($"&fromDate={fromDate}");

            if (toDate.HasValue)
                uriBuilder.Append($"&toDate={toDate}");

            return uriBuilder.ToString();
        }

        public static string GetSendPacksRoute(int pageNumber, int pageSize) => $"send/pack?pageNumber={pageNumber}&pageSize={pageSize}";
    }
}