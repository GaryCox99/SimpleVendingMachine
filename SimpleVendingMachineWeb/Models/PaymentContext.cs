using Microsoft.EntityFrameworkCore;

namespace SimpleVendingMachineWeb.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options) { }

        public DbSet<Payment> Payments { get; set; } = null;
    }
}
