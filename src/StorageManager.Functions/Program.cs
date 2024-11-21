using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;

using StorageManager.Application.Extensions;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();
builder.AddServiceDefaults();
builder.Services.RegisterApplicationLayer();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
