using StorageManager.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.RegisterApplicationLayer();

var app = builder.Build();
app.AddApplicationDefaults();
app.UseReDoc(options =>
{
    options.SpecUrl("/openapi/v1.json");
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
});

await app.RunAsync();

public partial class Program { }
