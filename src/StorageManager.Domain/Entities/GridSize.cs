using MongoDB.Bson.Serialization.Attributes;

namespace StorageManager.Domain.Entities
{
    public class GridSize
    {
        [BsonElement("rows")]
        public int Rows { get; set; }

        [BsonElement("columns")]
        public int Columns { get; set; }

        public GridSize(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentException("Rows must be greater than zero.");
            if (columns <= 0) throw new ArgumentException("Columns must be greater than zero.");
            Rows = rows;
            Columns = columns;
        }

        public override string ToString()
        {
            return $"{Rows}x{Columns}";
        }
    }
}
