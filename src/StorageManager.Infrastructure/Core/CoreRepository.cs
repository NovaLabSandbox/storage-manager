using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

namespace StorageManager.Infrastructure.Core
{
    public class CoreRepository
    {
        protected string _databaseName = "Novalab";
        protected readonly IMongoDatabase _database;
        protected readonly IMongoClient _mongoClient;

        public CoreRepository(IMongoClient mongoClient, IConfiguration configuration)
        {

            var configurationDbName = configuration["MongoDb:DbName"];
            if (!string.IsNullOrEmpty(configurationDbName))
                _databaseName = configurationDbName;

            _mongoClient = mongoClient;
            _database = _mongoClient.GetDatabase(_databaseName);
        }

    }
}
