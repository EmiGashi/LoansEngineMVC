using LoansEngineMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LoansEngineMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
    }
}
