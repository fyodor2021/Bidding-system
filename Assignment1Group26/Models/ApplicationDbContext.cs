using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1Group26.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bid> bids { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<AssetCondition> assetConditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Clothes" },
                    new Category { CategoryId = 2, CategoryName = "Cars" },
                    new Category { CategoryId = 3, CategoryName = "Electronics" }

                );


            modelBuilder.Entity<AssetCondition>().HasData(
                    new AssetCondition { AssetConditionId = 1, AssetConditionStatus = "New" },
                    new AssetCondition { AssetConditionId = 2, AssetConditionStatus = "Lightly Used" },
                    new AssetCondition { AssetConditionId = 3, AssetConditionStatus = "Used" }

                );

        

            modelBuilder.Entity<Client>().HasData(

                  new Client
                  {
                      ClienFirstName = "John",
                      ClienLastName = "Smith",
                      ClientId = 1,
                      ClientUserName = "john.smith@gmail.com",
                      ClientPassword = "password"

                  },

                  new Client
                  {
                      ClienFirstName = "vedoor",
                      ClienLastName = "Barakat",
                      ClientId = 2,
                      ClientUserName = "Vendor.Barakat@gmail.com",
                      ClientPassword = "password"
                  }



              );
           




        }



    }
}