namespace TaskManagement.Domain.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}