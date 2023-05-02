using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.CustomerService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;

namespace AndreTurismoApp.CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AndreTurismoAppCustomerServiceContext _context;

        public CustomersController(AndreTurismoAppCustomerServiceContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            return await _context.Customer.Include(c => c.Address.City).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.Include(c => c.Address.City).Where(c => c.Id == id).FirstAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "Create Customer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'AndreTurismoAppCustomerServiceContext.Customer'  is null.");
            }

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
