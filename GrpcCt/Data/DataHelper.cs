using GrpcCt.Grpc;

namespace GrpcCt.Data;

public static class DataHelper
{
    public static async Task AddData(IApplicationBuilder app)
    {
        using var scopeFactory = app.ApplicationServices.CreateAsyncScope();
        var repository = scopeFactory.ServiceProvider.GetRequiredService<IModelsRepository>()
            ?? throw new NullReferenceException(nameof(IModelsRepository));
        var grpcService = scopeFactory.ServiceProvider.GetRequiredService<GrpcModelsService>()
            ?? throw new NullReferenceException(nameof(GrpcModelsService));
        
        var models = await grpcService.GetData();

        foreach (var model in models)
        {
            repository.AddModel(model);
        }
        await repository.SaveChangesAsync();
    }
}