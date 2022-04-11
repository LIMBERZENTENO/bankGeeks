using Microsoft.EntityFrameworkCore;

namespace BankGeeks.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options) { 
        }

        public DbSet<Calculator> Calculator { get; set; }  
    }
}
