using FreelanceTrack.Domain.Enums;

namespace FreelanceTrack.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Active;
    public decimal? HourlyRate { get; set; }
    public decimal? FixedPrice { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Customer Customer { get; set; } = null!;
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}