using GrpcSrv.Models;

namespace GrpcSrv.Data;

public interface IModelsRepository
{
    void AddData(IEnumerable<Model> models);
    IQueryable<Model> GetData();
    Task SaveChangesAsync();
}