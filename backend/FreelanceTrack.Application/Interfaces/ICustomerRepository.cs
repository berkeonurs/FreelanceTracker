using FreelanceTrack.Domain.Entities;

namespace FreelanceTrack.Application.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllByUserIdAsync(string userId);
    Task<Customer?> GetByIdAsync(int id, string userId);
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
}