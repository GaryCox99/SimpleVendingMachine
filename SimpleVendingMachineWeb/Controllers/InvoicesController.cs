using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleVendingMachine.Models;

namespace SimpleVendingMachine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> Get()
        {
            return await _context.Invoices.ToListAsync();
        }

        // GET: Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = invoice.Id }, invoice);
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
