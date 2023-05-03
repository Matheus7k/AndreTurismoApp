using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoApp.PackageService.Data;
using System.Net.Sockets;

namespace AndreTurismoApp.PackageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly AndreTurismoAppPackageServiceContext _context;

        public PackagesController(AndreTurismoAppPackageServiceContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            try
            {
                return await _context.Package.Include(p => p.Hotel.Address.City)
                                         .Include(p => p.Ticket.Origin.City)
                                         .Include(p => p.Ticket.Destination.City)
                                         .Include(p => p.Ticket.Customer.Address.City)
                                         .Include(p => p.Customer.Address.City)
                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.Include(p => p.Hotel.Address.City)
                                         .Include(p => p.Ticket.Origin.City)
                                         .Include(p => p.Ticket.Destination.City)
                                         .Include(p => p.Ticket.Customer.Address.City)
                                         .Include(p => p.Customer.Address.City)
                                         .Where(p => p.Id == id)
                                         .FirstAsync();

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Package>> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            if (_context.Package == null)
            {
                return Problem("Entity set 'AndreTurismoAppPackageServiceContext.Package'  is null.");
            }

            try
            {
                _context.Entry(package).State = EntityState.Modified;
                _context.Package.Add(package);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return package;
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Package?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
