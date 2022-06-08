using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebAPI.Database
{
    public partial class eRestoranContext : DbContext
    {
        public eRestoranContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Jelo> Jelo { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public DbSet<StatusNarudzbe> StatusNarudzbe { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Uposlenik> Uposlenik { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Uplata> Uplata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Example --> modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.HasOne(d => d.Korisnik)
                    .WithOne(d => d.Uposlenik);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}