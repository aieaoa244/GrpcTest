using GrpcSrv.Data;
using GrpcSrv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrpcSrv.Controllers;

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
        var data = await _repository.GetData().ToListAsync();
        return Ok(data);
    }
}