using GrpcSrv.Data;
using GrpcSrv.Grpc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddDbContext<AppDbContext>(o =>
    o.UseInMemoryDatabase("Models"));
services.AddScoped<IModelsRepository, ModelsRepository>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddGrpc();
services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapGrpcService<GrpcModelService>();

await DataHelper.AddData(app);

app.Run();