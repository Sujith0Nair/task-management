using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories;

public class CommentRepository(ApplicationDbContext dbContext) : ICommentRepository
{
    public async Task<Comment?> GetByIdAsync(Guid commentId)
    {
        return await dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
    }

    public async Task<IReadOnlyList<Comment>> GetAllByTaskIdAsync(Guid taskId)
    {
        return await dbContext.Comments.Where(c => c.TaskId == taskId).ToListAsync();
    }

    public void Add(Comment comment)
    {
        dbContext.Comments.Add(comment);
    }

    public void Update(Comment comment)
    {
        dbContext.Comments.Update(comment);
    }

    public void Delete(Comment comment)
    {
        dbContext.Comments.Remove(comment);
    }
}