using GrpcCt.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcCt.Data;

public class ModelsRepository : IModelsRepository
{
    private readonly AppDbContext _context;

    public ModelsRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddModel(Model model)
    {
        _context.Models.Add(model);
    }

    public async Task<IEnumerable<Model>> GetData()
    {
        return await _context.Models.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
