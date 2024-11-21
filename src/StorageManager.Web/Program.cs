using Fluxor;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using StorageManager.Client;
using StorageManager.Client.Contracts;
using StorageManager.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAntDesign();
builder.Services.AddServiceDiscovery();
builder.Services.AddHttpClient<ISiteClient, SiteClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUri"]);
});

builder.Services.AddHttpClient<IAreaClient, AreaClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ApiUri"]);
});


builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));
await builder.Build().RunAsync();