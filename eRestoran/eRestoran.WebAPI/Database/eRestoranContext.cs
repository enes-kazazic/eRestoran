using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebAPI.Database
{
	public class eRestoranContext : DbContext
	{
		public eRestoranContext(DbContextOptions options)
			:base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Example --> modelBuilder.Entity<Course>().ToTable("Course");
			modelBuilder.Entity<Uposlenik>(entity =>
			{
				entity.HasOne(d => d.Korisnik)
					.WithOne(d => d.Uposlenik);
			});
        }

	}
}
