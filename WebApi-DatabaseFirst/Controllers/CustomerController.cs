using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_DatabaseFirst.Models;

namespace WebApi_DatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AdventureWorksLt2019Context _context;

        public CustomerController(AdventureWorksLt2019Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);

            if (customer == null){
                return BadRequest("Não encontrado");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok("Deletado");
        }

    }
}
