using AutoMapper;
using Grpc.Core;
using GrpcSrv.Data;
using Microsoft.EntityFrameworkCore;

namespace GrpcSrv.Grpc;

public class GrpcModelService : GrpcModels.GrpcModelsBase
{
    private readonly IModelsRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GrpcModelService> _logger;

    public GrpcModelService(IModelsRepository repository,
        IMapper mapper,
        ILogger<GrpcModelService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public override async Task<ModelsReply> GetModels(GetModelsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Models grpc endpoint hit");
        var reply = new ModelsReply();
        _logger.LogInformation("Retrieving data");
        var models = await _repository.GetData().ToListAsync();
        foreach (var model in models)
        {
            reply.Models.Add(_mapper.Map<GrpcModel>(model));
        }

        _logger.LogInformation("Sending grpc reply: {count} items", models.Count);
        return reply;
    }
}
