using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestrovka_3._0.Models;

namespace Semestrovka_3._0.Pages.DataConnection
{
    public abstract class AppDbContext : DbContext
    {
        protected abstract string TestDb { get; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        private string ConnectionString => $"Data Source=localhost;Initial Catalog={TestDb};Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(config => config.AddConsole()));
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    } 
}
