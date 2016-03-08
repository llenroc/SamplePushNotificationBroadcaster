using Newtonsoft.Json;

namespace SamplePushNotificationBroadcaster
{
    public class Alert
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class Aps
    {
        [JsonProperty("alert")]
        public Alert Alert { get; set; }

        [JsonProperty("badge")]
        public int Badge { get; set; }
    }

    public class ApnsNotificationPayload
    {
        [JsonProperty("aps")]
        public Aps Aps { get; set; }
    }
}