using Marketplace.Admin.API.Common;
using Marketplace.Admin.API.Configurations;
using Marketplace.Admin.Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors();

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

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

await app.Migrate();

app.Run();
