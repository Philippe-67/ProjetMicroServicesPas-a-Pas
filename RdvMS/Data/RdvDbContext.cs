using Microsoft.EntityFrameworkCore;
using RdvMS.Models.Rdv;

namespace RdvMS.Data
{
    public class RdvDbContext : DbContext
    {
        public RdvDbContext(DbContextOptions<RdvDbContext> options) : base(options)
        { 
        }
        // Ajoutez des DbSet pour chaque entité de votre modèle
        public DbSet<Rdv> Rdvs { get; set; }

        // Vous pouvez ajouter d'autres DbSets pour d'autres entités...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurez les relations, les index, les contraintes, etc.
            // Vous pouvez également utiliser des configurations Fluent API ici.

            // Exemple de configuration pour l'entité Rdv
            modelBuilder.Entity<Rdv>()
                .HasKey(r => r.Id);

            // D'autres configurations...

            base.OnModelCreating(modelBuilder);
        }
    }

}

