using System;

namespace IPE.SmsIrClient.Routes
{
    internal static class SendRoutes
    {
        internal static string BulkSendRoute() => "send/bulk";

        internal static string LikeToLikeSendRoute() => "send/likeTolike";

        internal static string RemoveScheduledMessagesRoute(Guid packId) => $"send/scheduled/{packId}";

        internal static string VerifySendRoute() => "send/verify";
    }
}