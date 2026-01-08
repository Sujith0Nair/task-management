using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid userId);
    Task<User?> GetByEmailAsync(string email);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}