namespace StorageManager.Core.Results
{
    public class CreatedResult<T>
    {
        public Guid Id { get; set; }

        public T Data { get; set; }

        public string EntityPath { get; set; }
    }
}
