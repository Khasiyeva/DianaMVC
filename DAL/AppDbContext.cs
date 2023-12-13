using DianaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
    }
}
