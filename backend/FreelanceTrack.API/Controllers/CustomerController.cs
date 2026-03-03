using System.Security.Claims;
using FreelanceTrack.Application.DTOs.Customer;
using FreelanceTrack.Application.Interfaces;
using FreelanceTrack.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    private string GetUserId() =>
        User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerRepository.GetAllByUserIdAsync(GetUserId());
        var response = customers.Select(c => new CustomerResponse
        {
            Id = c.Id,
            Name = c.Name,
            CompanyName = c.CompanyName,
            Email = c.Email,
            Phone = c.Phone,
            CreatedAt = c.CreatedAt
        });
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id, GetUserId());
        if (customer == null)
            return NotFound(new { message = "Müşteri bulunamadı." });

        return Ok(new CustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            CompanyName = customer.CompanyName,
            Email = customer.Email,
            Phone = customer.Phone,
            CreatedAt = customer.CreatedAt
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerRequest request)
    {
        var customer = new Customer
        {
            UserId = GetUserId(),
            Name = request.Name,
            CompanyName = request.CompanyName,
            Email = request.Email,
            Phone = request.Phone
        };

        var created = await _customerRepository.AddAsync(customer);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new CustomerResponse
        {
            Id = created.Id,
            Name = created.Name,
            CompanyName = created.CompanyName,
            Email = created.Email,
            Phone = created.Phone,
            CreatedAt = created.CreatedAt
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CustomerRequest request)
    {
        var customer = await _customerRepository.GetByIdAsync(id, GetUserId());
        if (customer == null)
            return NotFound(new { message = "Müşteri bulunamadı." });

        customer.Name = request.Name;
        customer.CompanyName = request.CompanyName;
        customer.Email = request.Email;
        customer.Phone = request.Phone;

        await _customerRepository.UpdateAsync(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id, GetUserId());
        if (customer == null)
            return NotFound(new { message = "Müşteri bulunamadı." });

        await _customerRepository.DeleteAsync(customer);
        return NoContent();
    }
}