using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository(ApplicationDbContext dbContext) : ITaskRepository
{
    public async Task<Task?> GetByIdAsync(Guid id)
    {
        return await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IReadOnlyList<Task>> GetAllByBoardIdAsync(Guid boardId)
    {
        return await dbContext.Tasks.Where(t => t.BoardId == boardId).ToListAsync();
    }

    public async Task<IReadOnlyList<Task>> GetAllByTenantIdAsync(Guid tenantId)
    {
        return await dbContext.Tasks.Where(t => t.TenantId == tenantId).ToListAsync();
    }

    public void Add(Task task)
    {
        dbContext.Tasks.Add(task);
    }

    public void Update(Task task)
    {
        dbContext.Tasks.Update(task);
    }

    public void Delete(Task task)
    {
        dbContext.Tasks.Remove(task);
    }
}