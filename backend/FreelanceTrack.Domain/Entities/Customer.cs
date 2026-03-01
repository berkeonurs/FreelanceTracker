namespace FreelanceTrack.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string UserId { get; set;} = string.Empty;
    public string Name { get; set;} = string.Empty;
    public string? CompanyName { get; set;}
    public string Email { get; set;} = string.Empty;
    public string? Phone { get; set;}
    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
    public ICollection<Project> Projects { get; set; } = new List<Project>();

}