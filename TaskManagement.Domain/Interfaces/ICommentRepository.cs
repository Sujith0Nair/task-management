using TaskManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Domain.Interfaces;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(Guid commentId);
    Task<IReadOnlyList<Comment>> GetAllByTaskIdAsync(Guid taskId);
    void Add(Comment comment);
    void Update(Comment comment);
    void Delete(Comment comment);
}