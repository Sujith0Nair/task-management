using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class BoardRepository(ApplicationDbContext dbContext) : IBoardRepository
{
    public async Task<Board?> GetByIdAsync(Guid id)
    {
        return await dbContext.Boards.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Board>> GetAllByProjectIdAsync(Guid projectId)
    {
        return await dbContext.Boards.Where(x => x.ProjectId == projectId).ToListAsync();
    }

    public void Add(Board project)
    {
        dbContext.Boards.Add(project);
    }

    public void Update(Board project)
    {
        dbContext.Boards.Update(project);
    }

    public void Delete(Board project)
    {
        dbContext.Boards.Remove(project);
    }
}