using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tp4.Core.Entities;



public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<MembershipType>? MembershipTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
                new Genre { id = 1, Name = "Romance" },
                new Genre { id = 2, Name = "Thriller" },
                new Genre { id = 3, Name = "Horror" }
            );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MembershipType>().HasData(
               new MembershipType { Id = 1, Name = "3 months", SignUpfee = 4, discountRate = 30, DurationInMonth = 3 },
               new MembershipType { Id = 2, Name = "9 months", SignUpfee = 455, discountRate = 30, DurationInMonth = 3 },
               new MembershipType { Id = 3, Name = "premium", SignUpfee = 43, discountRate = 30, DurationInMonth = 3 }
           );
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>().HasData(
           new Customer { Id = 1, Name = "maram", Email = "jhbjfdhbvj", Age = 12, MembershipTypeId = 1 },
           new Customer { Id = 2, Name = "maher", Email = "jhbjfdhbvj", Age = 12, MembershipTypeId = 2 },
           new Customer { Id = 3, Name = "refka", Email = "jhbjfdhbvj", Age = 12, MembershipTypeId = 3 }
       );

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Name = "Inception", GenreId = 1 },
            new Movie { Id = 2, Name = "The Hangover", GenreId = 2 },
            new Movie { Id = 3, Name = "The Shawshank Redemption", GenreId = 3}
        );
    }






}

