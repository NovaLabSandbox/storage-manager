using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class Site
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("icon")]
        public string Icon { get; set; }

        [BsonElement("areas")]
        public List<Area> Areas { get; set; } = new();

        [BsonElement("devices")]
        public List<string> DeviceIds { get; set; } = new List<string>();

    }
}
