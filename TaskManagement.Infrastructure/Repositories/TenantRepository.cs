using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class TenantRepository(ApplicationDbContext dbContext) : ITenantRepository
{   
    public async Task<Tenant?> GetByIdAsync(Guid id)
    {
        return await dbContext.Tenants.FirstOrDefaultAsync(t => t.Id == id);
    }

    public void Add(Tenant tenant)
    {
        dbContext.Tenants.Add(tenant);
    }

    public void Update(Tenant tenant)
    {
        dbContext.Tenants.Update(tenant);
    }

    public void Delete(Tenant tenant)
    {
        dbContext.Tenants.Remove(tenant);
    }
}