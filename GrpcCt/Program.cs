using GrpcCt.Data;
using GrpcCt.Grpc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region serilog config
builder.Logging.ClearProviders();
Serilog.ILogger logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.AddSerilog(logger);
services.AddSingleton(logger);
#endregion

services.AddDbContext<AppDbContext>(o =>
    o.UseInMemoryDatabase("Models"));
services.AddScoped<IModelsRepository, ModelsRepository>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IGrpcModelsService, GrpcModelsService>();
services.AddControllers();

var app = builder.Build();

app.MapControllers();

await DataHelper.AddData(app);

app.Run();