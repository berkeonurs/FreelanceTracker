namespace FreelanceTrack.Application.DTOs.Customer;

public class CustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string? CompanyName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
}