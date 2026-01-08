namespace TaskManagement.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
    
    public ICollection<Board> Boards { get; set; } = new  List<Board>();
}