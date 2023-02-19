using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment1Group26.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bid> bids { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<AssetCondition> AssetConditions{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Clothes" },
                    new Category { CategoryId = 2, CategoryName = "Cars" },
                    new Category { CategoryId = 3, CategoryName = "Electronics" }

                );


            modelBuilder.Entity<AssetCondition>().HasData(
                    new AssetCondition { AssetConditionId = 1, AssetConditionName = "New" },
                    new AssetCondition { AssetConditionId = 3, AssetConditionName = "Lightly Used" },
                    new AssetCondition { AssetConditionId = 4, AssetConditionName = "Used" }

                );

            modelBuilder.Entity<Bid>().HasData(
                    
                    new Bid { BidId = 1,
                             BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                             BidDescription = "Long sleeve turtleneck sweater",
                             BidCost= 20,
                             BidStartDate = DateTime.Now,
                             BidEndDate = new DateTime(2023,5,16),
                             AssetConditionId = 1,
                             CategoryId= 1,
                             ClientId= 1


                    },
                    new Bid
                    {
                        BidId =2,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 1

                    },
                    new Bid
                    {
                        BidId = 3,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 2

                    },
                    new Bid
                    {
                        BidId = 4,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 1

                    },
                    new Bid
                    {
                        BidId = 5,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 1

                    },
                    new Bid
                    {
                        BidId = 6,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 1

                    },
                    new Bid
                    {
                        BidId = 7,
                        BidName = "Zara CROP KNIT TURTLENECK SWEATER",
                        BidDescription = "Long sleeve turtleneck sweater",
                        BidCost = 20,
                        BidStartDate = DateTime.Now,
                        BidEndDate = new DateTime(2023, 5, 16),
                        AssetConditionId = 1,
                        CategoryId = 1,
                        ClientId = 2


                     }



                );

            modelBuilder.Entity<Client>().HasData(

                  new Client
                  {
                      ClienFirstName=  "John",
                      ClienLastName = "Smith",
                      ClientId= 1,
                      ClientUserName = "john.smith@gmail.com",
                      ClientPassword= "password"

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
