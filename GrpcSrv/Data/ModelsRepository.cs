using GrpcSrv.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcSrv.Data;

public class ModelsRepository : IModelsRepository
{
    private readonly AppDbContext _context;

    public void AddData(IEnumerable<Model> models)
    {
        _context.Models.AddRange(models);
    }

    public ModelsRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Model> GetData()
    {
        return _context.Models;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}