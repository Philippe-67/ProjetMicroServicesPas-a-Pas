// PraticienDbContext.cs
using Microsoft.EntityFrameworkCore;
using PraticienMS.Models;

namespace PraticienMS.Data
{
    public class PraticienDbContext : DbContext
    {
        public PraticienDbContext(DbContextOptions<PraticienDbContext> options) : base(options)
        {
        }

        public DbSet<Praticien> Praticiens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de l'entité Praticien si nécessaire
        }
    }
}
