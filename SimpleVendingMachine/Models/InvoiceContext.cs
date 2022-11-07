using Microsoft.EntityFrameworkCore;
using SimpleVendingMachineApi.Models;

namespace SimpleVendingMachine.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options) { }

        public DbSet<Invoice> Invoices { get; set; } = null;

    }
}
