using Marketplace.Admin.API.Common;
using Marketplace.Admin.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Persistence
builder.Services.AddPersistenceSetup(builder.Configuration);

// Application layer setup
builder.Services.AddApplicationSetup();

// Middleware
builder.Services.AddScoped<ExceptionHandlerMiddleware>();

builder.Logging.ClearProviders();

// Add serilog
if (builder.Environment.EnvironmentName != "Testing")
{
    builder.Host.UseLoggingSetup(builder.Configuration);
}


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.Migrate();

app.Run();
