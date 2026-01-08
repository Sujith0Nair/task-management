using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ILabelRepository
{
    Task<Label?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Label>> GetAllByIdAsync(Guid tenantId);
    
    void Add(Label label);
    void Update(Label label);
    void Delete(Label label);
}