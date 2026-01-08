namespace TaskManagement.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? DueDate { get; set; }
    
    public Guid BoardId { get; set; }
    public Board Board { get; set; }
    
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Label> Labels { get; set; } = new List<Label>();
}