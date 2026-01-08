namespace TaskManagement.Domain.Entities;

public class Label
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public ICollection<Task> Tasks { get; set; }
}