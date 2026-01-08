namespace TaskManagement.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public Guid TaskId { get; set; }
    public Task Task { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}