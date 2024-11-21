using StorageManager.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.RegisterApplicationLayer();

var app = builder.Build();
app.AddApplicationDefaults();

await app.RunAsync();
