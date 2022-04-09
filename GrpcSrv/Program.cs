using GrpcSrv.Data;
using GrpcSrv.Grpc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region serilog config
builder.Logging.ClearProviders();
Serilog.ILogger logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollOnFileSizeLimit: true)
    .CreateLogger();
builder.Logging.AddSerilog(logger);
services.AddSingleton(logger);
#endregion

services.AddDbContext<AppDbContext>(o =>
    o.UseInMemoryDatabase("Models"));
services.AddScoped<IModelsRepository, ModelsRepository>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddGrpc();
services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapGrpcService<GrpcModelService>();

await DataHelper.AddData(app, logger);

app.Run();