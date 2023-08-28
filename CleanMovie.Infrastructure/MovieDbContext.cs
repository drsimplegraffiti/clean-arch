using System;
using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure
{
	public class MovieDbContext: DbContext
	{
		public MovieDbContext(DbContextOptions<MovieDbContext> options) :base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Handle Decimals ===> Configure precision and scale for the Cost property
            modelBuilder.Entity<Movie>()
                .Property(m => m.RentalCost)
                .HasColumnType("decimal(10, 2)"); // 10 total digits, with 2 digits after the decimal point

            //Handle Decimals ===> TotalCost
            modelBuilder.Entity<Rental>()
                .Property(m => m.TotalCost)
                .HasColumnType("decimal(10, 2)"); // 10 total digits, with 2 digits after the decimal point

            // One to Many (Member and Rentals)
            modelBuilder.Entity<Member>()
                .HasOne<Rental>(s => s.Rental)
                .WithMany(r => r.Members)
                .HasForeignKey(s => s.RentalId);

            // many to many
            modelBuilder.Entity<MovieRental>()
                .HasKey(g => new { g.RentalId, g.MovieId });
        }
    }
}

