using System.Text.Json;
using AutoMapper;
using Grpc.Core;
using GrpcSrv.Data;
using Microsoft.EntityFrameworkCore;

namespace GrpcSrv.Grpc;

public class GrpcModelService : GrpcModels.GrpcModelsBase
{
    private readonly IModelsRepository _repository;
    private readonly IMapper _mapper;

    public GrpcModelService(IModelsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<ModelsReply> GetModels(GetModelsRequest request, ServerCallContext context)
    {
        var reply = new ModelsReply();
        var models = await _repository.GetData().ToListAsync();
        foreach (var model in models)
        {
            reply.Models.Add(_mapper.Map<GrpcModel>(model));
        }

        Console.WriteLine($"Sending grpc reply: {JsonSerializer.Serialize(reply)}");
        return reply;
    }
}
