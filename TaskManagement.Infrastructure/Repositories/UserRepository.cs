using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }
}