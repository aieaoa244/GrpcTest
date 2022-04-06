using System.Text.Json;
using AutoMapper;
using Grpc.Net.Client;
using GrpcCt.Models;
using Mapster;

namespace GrpcCt.Grpc;

public class GrpcModelsService
{
    private readonly IMapper _mapper;

    public GrpcModelsService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<Model>> GetData()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:7000");
        var client = new GrpcModels.GrpcModelsClient(channel);

        var data = new List<Model>();
        try
        {
            Console.WriteLine("Calling grpc server");
            var reply = await client.GetModelsAsync(new GetModelsRequest());
            foreach (var grpcModel in reply.Models)
            {
                // data.Add(_mapper.Map<Model>(grpcModel));
                data.Add(grpcModel.Adapt<Model>());
            }
                
            Console.WriteLine($"Data acquired: {JsonSerializer.Serialize(data)}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Grpc call error: {e.Message}");
        }

        return data;
    }
}