﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleVendingMachine.Models;

namespace SimpleVendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly InvoiceItemContext _context;

        public InvoiceItemsController(InvoiceItemContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItems()
        {
            return await _context.InvoiceItems.ToListAsync();
        }

        // GET: InvoiceItems
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItemsByInvoice(int invoiceId)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.InvoiceId == invoiceId).ToListAsync();
            if (invoiceItems.Count < 1)
            {
                return NotFound();
            }
            return invoiceItems;
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItem>> GetInvoiceItem(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);

            if (invoiceItem == null)
            {
                return NotFound();
            }

            return invoiceItem;
        }

        // PUT: api/InvoiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceItem(int id, InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceItemExists(id))
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

        // POST: api/InvoiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceItem>> PostInvoiceItem(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Add(invoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoiceItem), new { id = invoiceItem.Id }, invoiceItem);
        }

        // DELETE: api/InvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            _context.InvoiceItems.Remove(invoiceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceItemExists(int id)
        {
            return _context.InvoiceItems.Any(e => e.Id == id);
        }
    }
}
