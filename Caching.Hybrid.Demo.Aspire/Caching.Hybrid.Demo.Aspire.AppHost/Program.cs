var builder = DistributedApplication.CreateBuilder(args);

//var redis = builder.AddRedis()

builder.Build().Run();
