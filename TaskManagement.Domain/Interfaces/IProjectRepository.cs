using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Project>> GetAllByTenantIdAsync(Guid tenantId);
    void Add(Project project);
    void Update(Project project);
    void Delete(Project project);
}