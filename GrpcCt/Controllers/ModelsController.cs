using GrpcCt.Data;
using GrpcCt.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrpcCt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : ControllerBase
{
    private readonly IModelsRepository _repository;

    public ModelsController(IModelsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ActionResult<IEnumerable<Model>>> GetData()
    {
        var data = await _repository.GetData();
        return Ok(data);
    }
}