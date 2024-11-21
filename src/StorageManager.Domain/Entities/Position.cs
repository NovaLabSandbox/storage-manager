using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class Position
    {
        [BsonElement("x")]
        public int X { get; set; }

        [BsonElement("y")]
        public int Y { get; set; }

        public Position(int x, int y)
        {
            if (x < 0) throw new ArgumentException("X must be non-negative.");
            if (y < 0) throw new ArgumentException("Y must be non-negative.");
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
