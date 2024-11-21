using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ip")]
        public string? Ip { get; set; }

        [BsonElement("mac")]
        public string? Mac { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [BsonElement("sites")]
        public List<string> SiteIds { get; set; } = new List<string>();

        [BsonElement("areas")]
        public List<string> AreaIds { get; set; } = new List<string>();

        [BsonElement("modules")]
        public List<string> ModuleIds { get; set; } = new List<string>();
    }
}
