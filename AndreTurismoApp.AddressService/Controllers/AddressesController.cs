using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Services;

namespace AndreTurismoApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurismoAppAddressServiceContext _context;
        private readonly PostOfficeService _postOfficeService;

        public AddressesController(AndreTurismoAppAddressServiceContext context, PostOfficeService postOfficeService)
        {
            _context = context;
            _postOfficeService = postOfficeService;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            return await _context.Address.Include(a => a.City).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.Include(a => a.City).Where(a => a.Id == id).FirstAsync();

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("/api/Addresses/cep/{cep}", Name = "Get By CEP")]
        public async Task<Address> GetAddressCEP(string cep)
        {
            AddressDTO addressDto = _postOfficeService.GetCep(cep).Result;

            City city = await _context.City.Where(c => c.Description == addressDto.localidade).FirstAsync();

            Address fullAddress = new(addressDto);

            fullAddress.Complement = addressDto.complemento;
            fullAddress.Neighborhood = addressDto.bairro;
            fullAddress.DateCreated = DateTime.Now;

            if (city != null)
            {
                fullAddress.City = city;

                _context.Entry(fullAddress).State = EntityState.Modified;
                _context.Address.Add(fullAddress);
                await _context.SaveChangesAsync();

                return fullAddress;
            }
            else
            {
                fullAddress.City = new City() { Description = addressDto.localidade };

                _context.Address.Add(fullAddress);
                await _context.SaveChangesAsync();

                return fullAddress;
            }
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = "Create Address")]
        public async Task<ActionResult<Address>> PostAddress(CreateAddressDTO createAddressDTO)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
            }

            AddressDTO addressDto = _postOfficeService.GetCep(createAddressDTO.CEP).Result;

            Address fullAddress = new(addressDto);

            fullAddress.Complement = addressDto.complemento;
            fullAddress.Neighborhood = addressDto.bairro;
            fullAddress.Number = createAddressDTO.Number;
            fullAddress.DateCreated = DateTime.Now;

            City city = await _context.City.Where(c => c.Description == addressDto.localidade).FirstOrDefaultAsync();

            if (city != null)
            {                
                fullAddress.City = city;

                _context.Entry(fullAddress).State = EntityState.Modified;
                _context.Address.Add(fullAddress);
                await _context.SaveChangesAsync();

                return fullAddress;
            }
            else
            {
                fullAddress.City = new City() { Description = addressDto.localidade };

                _context.Address.Add(fullAddress);
                await _context.SaveChangesAsync();

                return fullAddress;
            }                       
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
