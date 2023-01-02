using CinemaMovies.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaMovies.Data
{
    public class CinemaMoviesContext : DbContext
    {
        public CinemaMoviesContext(DbContextOptions<CinemaMoviesContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<User> Users { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var items = modelBuilder.Entity<Item>();
            items.HasKey(i => i.ItemId);

            var movies = modelBuilder.Entity<Movie>();
            movies.HasKey(m => m.MovieId);

            var movieReviews = modelBuilder.Entity<MovieReview>();
            movieReviews.HasKey(mr => mr.MowieReviewId);
            movieReviews.HasOne(mr => mr.Movie).WithMany(m => m.MovieReviews);

            var purchases = modelBuilder.Entity<Purchase>();
            purchases.HasKey(p => p.PurchaseId);
            //purchases.HasMany().WithOne()

            var purchaseItems = modelBuilder.Entity<PurchaseItem>();
            purchaseItems.HasKey(pi => pi.PurchaseItemId);
            //purchaseItems.HasOne().WithMany()

            var users = modelBuilder.Entity<User>();
            users.HasKey(m => m.UserId);

        }


    }
}
