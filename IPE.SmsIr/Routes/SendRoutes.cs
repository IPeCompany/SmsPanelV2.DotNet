using System;

namespace IPE.SmsIr.Routes
{
    public static class SendRoutes
    {
        public static string BulkSendRoute() => "send/bulk";

        public static string LikeToLikeSendRoute() => "send/likeTolike";

        public static string RemoveScheduledMessagesRoute(Guid packId) => $"send/scheduled/{packId}";

        public static string VerifySendRoute() => "send/verify";
    }
}