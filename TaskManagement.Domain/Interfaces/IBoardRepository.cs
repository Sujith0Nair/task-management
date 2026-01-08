using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces;

public interface IBoardRepository
{
    Task<Board?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Board>> GetAllByProjectIdAsync(Guid projectId);
    void Add(Board project);
    void Update(Board project);
    void Delete(Board project);
}