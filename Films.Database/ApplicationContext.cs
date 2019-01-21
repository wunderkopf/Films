using Microsoft.EntityFrameworkCore;

namespace Films.Database
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<FilmGenre> FilmsGenres { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.10;Port=5432;Database=film;Username=film;Password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilmGenre>().HasKey(x => new { x.FilmId, x.GenreId });
            modelBuilder.Entity<FilmGenre>().HasOne(pt => pt.Film).WithMany(p => p.FilmGenre).HasForeignKey(pt => pt.FilmId);
            modelBuilder.Entity<FilmGenre>().HasOne(pt => pt.Genre).WithMany(p => p.FilmGenre).HasForeignKey(pt => pt.GenreId);
        }
    }
}
