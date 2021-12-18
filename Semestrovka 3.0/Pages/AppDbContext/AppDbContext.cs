using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestrovka_3._0.Models;

namespace Semestrovka_3._0.Pages.DataConnection
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
