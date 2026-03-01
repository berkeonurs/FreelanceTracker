namespace FreelanceTrack.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = string.Empty;
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
    public Invoice Invoice { get; set; } = null!;
}