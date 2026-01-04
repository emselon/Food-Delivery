using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// load ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// add ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// use ocelot
await app.UseOcelot();

app.Run();
