using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(
    path: builder.Configuration["OcelotConfiguration"]);

var ocelotConfiguration = new ConfigurationBuilder()
                            .AddJsonFile(builder.Configuration["OcelotConfiguration"])
                            .Build();

builder.Services.AddOcelot(ocelotConfiguration)
    .AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

app.Run();
app.UseOcelot();
