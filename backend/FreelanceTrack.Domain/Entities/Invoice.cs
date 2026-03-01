using FreelanceTrack.Domain.Enums;

namespace FreelanceTrack.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public decimal SubTotal { get; set; }
    public decimal TaxRate { get; set; } = 18;
    public decimal Total { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Project Project { get; set; } = null!;
    public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}