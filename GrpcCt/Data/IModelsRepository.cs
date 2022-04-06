using GrpcCt.Models;

namespace GrpcCt.Data;

public interface IModelsRepository
{
    void AddModel(Model model);
    Task<IEnumerable<Model>> GetData();

    Task SaveChangesAsync();
}