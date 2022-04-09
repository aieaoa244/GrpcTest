using AutoMapper;
using Grpc.Net.Client;
using GrpcCt.Models;
using Mapster;

namespace GrpcCt.Grpc;

public class GrpcModelsService : IGrpcModelsService
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GrpcModelsService(IMapper mapper,
        ILogger<GrpcModelsService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<Model>> GetData()
    {
        var uri = "https://localhost:7000";
        using var channel = GrpcChannel.ForAddress(uri);
        var client = new GrpcModels.GrpcModelsClient(channel);

        var data = new List<Model>();
        try
        {
            _logger.LogInformation("Calling grpc server at {uri}", uri);
            var reply = await client.GetModelsAsync(new GetModelsRequest());
            foreach (var grpcModel in reply.Models)
            {
                // data.Add(_mapper.Map<Model>(grpcModel));
                data.Add(grpcModel.Adapt<Model>());
            }
            
            _logger.LogInformation("Data acquired: {count} items", data.Count);
        }
        catch (Exception e)
        {
            _logger.LogError($"Grpc call error: {e.Message}");
        }

        return data;
    }
}