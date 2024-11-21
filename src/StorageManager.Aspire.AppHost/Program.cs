using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var mongodb = builder.AddMongoDB("database")
                        .WithMongoExpress()
                        .WithDataVolume("mongodb");

var cache = builder.AddRedis("cache")
                        .WithRedisInsight();

var messageQueue = builder.AddRabbitMQ("messageQueue")
                            .WithManagementPlugin(15888);

//var function = builder.AddAzureFunctionsProject<Projects.StorageManager_Functions>("az-functions")
//                        .WithDaprSidecar()
//                        .WithReference(cache)
//                        .WithReference(mongodb)
//                        .WithReference(messageQueue)
//                        .WaitFor(cache)
//                        .WaitFor(mongodb)
//                        .WaitFor(messageQueue)
//                        .WithExternalHttpEndpoints();

var backend = builder.AddProject<Projects.StorageManager_Service_Host>("backend")
                        .WithDaprSidecar()
                        .WithReference(cache)
                        .WithReference(mongodb)
                        .WithReference(messageQueue)
                        .WaitFor(cache)
                        .WaitFor(mongodb)
                        .WaitFor(messageQueue);


var frontend = builder.AddProject<Projects.StorageManager_Web>("frontend")
                        .WithDaprSidecar()
                        .WithReference(backend)
                        .WaitFor(backend);

builder.Build().Run();
