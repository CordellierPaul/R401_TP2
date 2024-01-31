using Microsoft.EntityFrameworkCore;

namespace TP2_Series_API_Web.Models.EntityFramework
{
    public partial class SeriesDbContext : DbContext
    {
        public virtual DbSet<Serie> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=SeriesDB; uid=postgres; password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>(entity =>
            {
                entity.HasKey(e => e.SerieId).HasName("serie_pkey");
                entity.ToTable("serie");
                entity.Property(e => e.SerieId).HasColumnName("serieid");
                entity.Property(e => e.AnneeCreation).HasColumnName("anneecreation");
                entity.Property(e => e.NbEpisodes).HasColumnName("nbepisodes");
                entity.Property(e => e.NbSaisons).HasColumnName("nbsaisons");
                entity.Property(e => e.Network)
                    .HasMaxLength(50)
                    .HasColumnName("network");
                entity.Property(e => e.Resume).HasColumnName("resume");
                entity.Property(e => e.Titre)
                    .HasMaxLength(100)
                    .HasColumnName("titre");
            });
        }
    }
}
