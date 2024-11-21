using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var mongodb = builder.AddMongoDB("mongodb")
                        .WithMongoExpress();

var cache = builder.AddRedis("redis")
                        .WithRedisInsight();

var messageQueue = builder.AddRabbitMQ("messageQueue")
                            .WithManagementPlugin(15888);

var function = builder.AddAzureFunctionsProject<Projects.StorageManager_Functions>("az-functions")
                        .WithDaprSidecar()
                        .WithReference(cache)
                        .WithReference(mongodb)
                        .WithReference(messageQueue)
                        .WaitFor(cache)
                        .WaitFor(mongodb)
                        .WaitFor(messageQueue)
                        .WithExternalHttpEndpoints();

builder.Build().Run();
