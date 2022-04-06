using GrpcCt.Data;
using GrpcCt.Grpc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDbContext<AppDbContext>(o =>
    o.UseInMemoryDatabase("Models"));
services.AddScoped<IModelsRepository, ModelsRepository>();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<GrpcModelsService>();
services.AddControllers();

var app = builder.Build();

app.MapControllers();

await DataHelper.AddData(app);

app.Run();