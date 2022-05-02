using System.Text;

namespace IPE.SmsIrClient.Routes
{
    internal static class ReceiveRoutes
    {
        internal static string GetLatestReceivesRoute(int count) => $"receive/latest?count={count}";

        internal static string GetLiveReceivesRoute(int pageNumber, int pageSize) => $"receive/live?pageNumber={pageNumber}&pageSize={pageSize}";

        internal static string GetArchivedReceivesRoute(int pageNumber, int pageSize, int? fromDate, int? toDate)
        {
            StringBuilder uriBuilder = new StringBuilder($"receive/archive?pageNumber={pageNumber}&pageSize={pageSize}");

            if (fromDate.HasValue)
                uriBuilder.Append($"&fromDate={fromDate}");

            if (toDate.HasValue)
                uriBuilder.Append($"&toDate={toDate}");

            return uriBuilder.ToString();
        }
    }
}