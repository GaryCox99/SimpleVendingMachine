using Microsoft.EntityFrameworkCore;

namespace SimpleVendingMachine.Models
{
    public class InvoiceItemContext : DbContext
    {
        public InvoiceItemContext(DbContextOptions<InvoiceItemContext> options)
            : base(options) { }

        public DbSet<InvoiceItem> InvoiceItems { get; set; } = null;
    }
}
