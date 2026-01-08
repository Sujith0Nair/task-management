using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class ProjectRepository(ApplicationDbContext dbContext) : IProjectRepository
{
    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Project>> GetAllByTenantIdAsync(Guid tenantId)
    {
        return await dbContext.Projects.Where(p => p.TenantId == tenantId).ToListAsync(); 
    }

    public void Add(Project project)
    {
        dbContext.Projects.Add(project);
    }

    public void Update(Project project)
    {
        dbContext.Projects.Update(project);
    }

    public void Delete(Project project)
    {
        dbContext.Projects.Remove(project);
    }
}