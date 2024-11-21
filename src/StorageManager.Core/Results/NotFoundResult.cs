namespace StorageManager.Core.Results
{
    public class NotFoundResult
    {
        public NotFoundResult()
        {

        }

        public NotFoundResult(string entityType, Guid id)
        {
            EntityType = entityType;
            Id = id;
        }

        public string EntityType { get; set; }
        public Guid Id { get; set; }
    }
}
