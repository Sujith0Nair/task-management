using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class LabelRepository(ApplicationDbContext dbContext) : ILabelRepository
{
    public async Task<Label?> GetByIdAsync(Guid id)
    {
        return await dbContext.Labels.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IReadOnlyList<Label>> GetAllByIdAsync(Guid tenantId)
    {
        return await dbContext.Labels.Where(l => l.TenantId == tenantId).ToListAsync();
    }

    public void Add(Label label)
    {
        dbContext.Labels.Add(label);
    }

    public void Update(Label label)
    {
        dbContext.Labels.Update(label);
    }

    public void Delete(Label label)
    {
        dbContext.Labels.Remove(label);
    }
}