using JobPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll() 
            => await _context.Customers.ToArrayAsync();

        [HttpPost]
        public async Task<Customer> Add([FromBody] Customer c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            _context.Customers.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
