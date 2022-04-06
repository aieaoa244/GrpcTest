using GrpcSrv.Models;

namespace GrpcSrv.Data;

public static class DataHelper
{
    public static async Task AddData(IApplicationBuilder app)
    {
        using var scopeFactory = app.ApplicationServices.CreateAsyncScope();
        var repository = scopeFactory.ServiceProvider.GetRequiredService<IModelsRepository>()
            ?? throw new NullReferenceException(nameof(IModelsRepository));
        
        var models = new List<Model> {
            new Model { Id = 1, Name = "Model 1"},
            new Model { Id = 2, Name = "Model 2"},
            new Model { Id = 3, Name = "Model 3"},
            new Model { Id = 4, Name = "Model 4"},
            new Model { Id = 5, Name = "Model 5"},
        };

        repository.AddData(models);
        await repository.SaveChangesAsync();
    }
}