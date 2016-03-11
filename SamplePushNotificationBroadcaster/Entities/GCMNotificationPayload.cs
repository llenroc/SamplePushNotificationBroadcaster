using Newtonsoft.Json;

namespace SamplePushNotificationBroadcaster
{
    internal class GcmNotificationPayload
    {
        [JsonProperty("badge")]
        public string Badge { get; set; }

        [JsonProperty("jobId")]
        public int JobId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}