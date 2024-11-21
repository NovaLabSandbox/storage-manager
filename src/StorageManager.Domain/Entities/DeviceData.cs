using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class DeviceData
    {
        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("deviceId")]
        public string DeviceId { get; set; }

        [BsonElement("data")]
        public Dictionary<string, object> Data { get; set; }

        [BsonElement("command")]
        public Dictionary<string, object> Command { get; set; }
    }
}
