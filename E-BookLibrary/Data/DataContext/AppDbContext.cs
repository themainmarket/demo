using E_BookLibrary.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_BookLibrary.Data.DataContext
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Rating> RatingTbl { get; set; }
        public DbSet<Review> ReviewTbl { get; set; }
        public DbSet<Book> BookTbl { get; set; }
        public DbSet<Category> CategoryTbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasMany(x => x.Review)
                .WithOne(x => x.User)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
               .HasMany(x => x.Ratings)
               .WithOne(x => x.User)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Category>()
                .HasMany(p => p.Books)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder
                .Entity<Book>()
                .HasOne(p => p.Rating)
                .WithOne(p => p.Book)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
               .Entity<Book>()
               .HasMany(p => p.Review)
               .WithOne(p => p.Book)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Rating>()
                .HasOne(x => x.User)
                .WithMany(x => x.Ratings)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
