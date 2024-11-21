using System.Reflection;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class Area
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

        [BsonElement("gridSize")]
        public GridSize GridSize { get; set; }

        [BsonElement("modules")]
        public List<Module> Modules { get; set; } = new();

        [BsonElement("devices")]
        public List<string> DeviceIds { get; set; } = new List<string>();
    }
}
