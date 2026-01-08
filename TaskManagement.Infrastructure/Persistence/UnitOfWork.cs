using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Infrastructure.Persistence;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}