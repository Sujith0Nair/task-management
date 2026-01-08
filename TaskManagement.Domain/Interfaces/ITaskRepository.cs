namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<Domain.Entities.Task?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Domain.Entities.Task>> GetAllByBoardIdAsync(Guid boardId);
    Task<IReadOnlyList<Domain.Entities.Task>> GetAllByTenantIdAsync(Guid tenantId);
    void Add(Domain.Entities.Task task);
    void Update(Domain.Entities.Task task);
    void Delete(Domain.Entities.Task task);
}