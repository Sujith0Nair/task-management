using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ITenantRepository
{
    Task<Tenant?> GetByIdAsync(Guid id);
    void Add(Tenant tenant);
    void Update(Tenant tenant);
    void Delete(Tenant tenant);
}