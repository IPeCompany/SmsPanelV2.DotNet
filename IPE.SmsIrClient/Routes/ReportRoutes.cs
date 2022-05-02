using System;
using System.Text;

namespace IPE.SmsIrClient.Routes
{
    internal static class ReportRoutes
    {
        internal static string GetSingleMessageReportRoute(int messageId) => $"send/{messageId}";

        internal static string GetPackReportRoute(Guid packId) => $"send/pack/{packId}";

        internal static string GetLiveReportRoute(int pageNumber, int pageSize) => $"send/live?pageNumber={pageNumber}&pageSize={pageSize}";

        internal static string GetArchivedReportRoute(int pageNumber, int pageSize, int? fromDate, int? toDate)
        {
            StringBuilder uriBuilder = new StringBuilder($"send/archive?pageNumber={pageNumber}&pageSize={pageSize}");

            if (fromDate.HasValue)
                uriBuilder.Append($"&fromDate={fromDate}");

            if (toDate.HasValue)
                uriBuilder.Append($"&toDate={toDate}");

            return uriBuilder.ToString();
        }

        internal static string GetSendPacksRoute(int pageNumber, int pageSize) => $"send/pack?pageNumber={pageNumber}&pageSize={pageSize}";
    }
}