using GrpcCt.Models;

namespace GrpcCt.Grpc;

public interface IGrpcModelsService
{
    Task<IEnumerable<Model>> GetData();
}