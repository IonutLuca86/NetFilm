

using NetFilm.Common.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<NetFilmHttpClient>(client => client.BaseAddress = new Uri("https://localhost:7001/api/"));
builder.Services.AddScoped<IClientService, ClientService>();

await builder.Build().RunAsync();
