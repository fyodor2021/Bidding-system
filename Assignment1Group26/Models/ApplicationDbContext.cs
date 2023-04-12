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
        public DbSet<Review> reviews { get; set; }
        public DbSet<BidsPlaced> bidsPlaced { get; set; }

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

            
            /*
            modelBuilder.Entity<Client>().HasData(

                  new Client
                  {
                      ClientFirstName = "John",
                      ClientLastName = "Smith",
                      ClientId = 1,
                      ClientUserName = "john.smith@gmail.com",
                      ClientPassword = "password",
                      EmailConfirmed = true,
                      ClientRole = "Client"
                  },

                  new Client
                  {
                      ClientFirstName = "vedoor",
                      ClientLastName = "Barakat",
                      ClientId = 2,
                      ClientUserName = "Vedoor.Barakat@gmail.com",
                      ClientPassword = "password",
                      EmailConfirmed = true,
                      ClientRole = "Client"
                  },
                  new Client
                  {
                      ClientFirstName = "josephine",
                      ClientLastName = "abdulaziz",
                      ClientId = 3,
                      ClientUserName = "juju.josedore@gmail.com",
                      ClientPassword = "juju123",
                      EmailConfirmed = true,
                      ClientRole = "Admin"
                  }


              );

            modelBuilder.Entity<BidsPlaced>().HasData(

                  new BidsPlaced
                  {
                      BidsPlacedId = 1,
                      BidId = 1,
                      ClientId = 1,
                      BidAmount = 17000,
                      
                  },

                  new BidsPlaced
                  {
                      BidsPlacedId = 2,
                      BidId = 1,
                      ClientId = 1,
                      BidAmount = 18000,

                  },
                  new BidsPlaced
                  {
                      BidsPlacedId = 3,
                      BidId = 1,
                      ClientId = 1,
                      BidAmount = 19000,
                  },
                  new BidsPlaced
                  {
                      BidsPlacedId = 4,
                      BidId = 1,
                      ClientId = 2,
                      BidAmount = 20000,
                  },
                  new BidsPlaced
                  {
                      BidsPlacedId = 5,
                      BidId = 1,
                      ClientId = 2,
                      BidAmount = 21000,
                  }

              );
            
        //    modelBuilder.Entity<Bid>().HasData(
        //             new Bid
        //             {
        //                 BidId = 1,
        //                 BidName = "LACE UP TIED HIGH HEELED SHOES",
        //                 BidDescription = "High heel slingback shoes. Tied closure. Pointed toe.",
        //                 BidStartDate = DateTime.Now,
        //                 BidEndDate = DateTime.Now,
        //                 BidCost = 59.99,
        //                 CategoryId = 1,
        //                 AssetConditionId = 1,
        //                 ClientId = 1
        //}
        //);

            /*
             new Bid
             {
                 BidId = 2,
                 BidName = "MINI CITY BAG",
                 BidDescription = "Mini city bag. Handle and removable, adjustable crossbody strap. Magnetic closure.",
                 BidStartDate = DateTime.Now,
                 BidEndDate = DateTime.Now,
                 BidCost = 45.90,
                 CategoryId = 1,
                 AssetConditionId = 2,
                 ClientId = 1,
                 ImagePath = "~/Images/pinkBag.jpg"

             },
                new Bid
                {
                    BidId = 3,
                    BidName = "WOMEN'S BELT LOOP CARGO TRF JEANS",
                    BidDescription = "Mid-rise jeans with front pockets .",
                    BidStartDate = DateTime.Now,
                    BidEndDate = DateTime.Now,
                    BidCost = 69.99,
                    CategoryId = 1,
                    AssetConditionId = 1,
                    ClientId = 1,
                   // ImagePath = "~/Images/jeans.jpg"

                },
                    new Bid
                    {
                        BidId = 4,
                        BidName = "RUFFLED KNIT TOP",
                        BidDescription = "Openwork knit top with round neck and short sleeves.",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 39.99,
                        CategoryId = 1,
                        AssetConditionId = 1,
                        ClientId = 1,
    /ImagePath = "~/Images/knitShirt.jpg"

                    },
                    new Bid
                    {
                        BidId = 5,
                        BidName = "ZIP COLLAR SWEATSHIRT",
                        BidDescription = "Long sleeves. Rib trim.",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 29.99,
                        CategoryId = 1,
                        AssetConditionId = 3,
                        ClientId = 1,
                        ImagePath = "~/Images/menBlueHoddie.jpg"

                    },
                     new Bid
                     {
                         BidId = 6,
                         BidName = "WOOL BLEND COAT",
                         BidDescription = "Coat made of wool blend fabric.",
                         BidStartDate = DateTime.Now,
                         BidEndDate = DateTime.Now,
                         BidCost = 129.99,
                         CategoryId = 1,
                         AssetConditionId = 1,
                         ClientId = 1,
                         ImagePath = "~/Images/coat.jpg"

                     },
                    new Bid
                    {
                        BidId = 7,
                        BidName = "RUNNING SHOES",
                        BidDescription = "Sneakers.Slightly chunky soles.",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 129.99,
                        CategoryId = 1,
                        AssetConditionId = 2,
                        ClientId = 1,
                        ImagePath = "~/Images/runningShoes.jpg"

                    },
                    new Bid
                    {
                        BidId = 8,
                        BidName = "TEXTURED KNIT VEST",
                        BidDescription = "Cotton sweater vest. Sleeveless. V-neckline. Rib trim.",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 19.99,
                        CategoryId = 1,
                        AssetConditionId = 3,
                        ClientId = 1,
                        ImagePath = "~/Images/vest.jpg"

                    },
                    new Bid
                    {
                        BidId = 9,
                        BidName = "ASSYMETRIC POPLIN DRESS",
                        BidDescription = "Girl short sleeves dress with elastic cuffs.",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 29.99,
                        CategoryId = 1,
                        AssetConditionId = 1,
                        ClientId = 1,
                        ImagePath = "~/Images/girlDress.jpg"

                    },
                    new Bid
                    {
                        BidId = 10,
                        BidName = "LENOVO IdeaPad 3",
                        BidDescription = "onsumer Notebook 15.6 FHD AMD Ryzen 5 5625U AMD Radeon Graphics 12GB 512GB SSD Windows 11 Home ",
                        BidStartDate = DateTime.Now,
                        BidEndDate = DateTime.Now,
                        BidCost = 649.99,
                        CategoryId = 3,
                        AssetConditionId = 3,
                        ClientId = 1,
                        ImagePath = "~/Images/lenovoIdeaPad3.jpg"

                    },
                         new Bid
                         {
                             BidId = 11,
                             BidName = "HP OMEN 16-b0020ca Gaming Notebook",
                             BidDescription = "16.1 QHD, Intel Core i7-11800H, NVIDIA GeForce RTX 3070, 16GB DDR4, 1TB SSD.",
                             BidStartDate = DateTime.Now,
                             BidEndDate = DateTime.Now,
                             BidCost = 1200.99,
                             CategoryId = 3,
                             AssetConditionId = 1,
                             ClientId = 1,
                             ImagePath = "~/Images/omen.jpg"

                         },
                          new Bid
                          {
                              BidId = 12,
                              BidName = "IPHONE 14 PRO MAX",
                              BidDescription = "256GB Gold",
                              BidStartDate = DateTime.Now,
                              BidEndDate = DateTime.Now,
                              BidCost = 899.99,
                              CategoryId = 3,
                              AssetConditionId = 3,
                              ClientId = 1,
                              ImagePath = "~/Images/iphone14.jpg"

                          },
                          new Bid
                          {
                              BidId = 13,
                              BidName = "MAZDA 3",
                              BidDescription = "2018 MAZDA 3",
                              BidStartDate = DateTime.Now,
                              BidEndDate = DateTime.Now,
                              BidCost = 25250,
                              CategoryId = 2,
                              AssetConditionId = 1,
                              ClientId = 2,
                              ImagePath = "~/Images/mazda32018.jpg"

                          },
                          new Bid
                          {
                              BidId = 14,
                              BidName = "Golf R",
                              BidDescription = "VW 310 Rampaging German Horse Power",
                              BidStartDate = DateTime.Now,
                              BidEndDate = DateTime.Now,
                              BidCost = 50150.00,
                              CategoryId = 2,
                              AssetConditionId = 1,
                              ClientId = 1,
                              ImagePath = "~/Images/golfR.jpg"

                          },
                          new Bid
                          {
                              BidId = 15,
                              BidName = "Chevy Silverado",
                              BidDescription = "2023 chevy pick up Truck",
                              BidStartDate = DateTime.Now,
                              BidEndDate = DateTime.Now,
                              BidCost = 70120.30,
                              CategoryId = 2,
                              AssetConditionId = 1,
                              ClientId = 2,
                              ImagePath = "~/Images/chevySilverado.jpg"

                          }






    */
            modelBuilder.Entity<Review>().HasData(

                  new Review
                  {
                      ReviewId = 1,
                      ClientId = 1,
                      CreatedBy = 1,
                      CreatedByStr = "john.smith@gmail.com",
                     Comment = "Awsome Experience, it was Delvired on Time, #HappyCustomer"
                  },

                  new Review
                  {
                      ReviewId = 2,
                      ClientId = 1,
                      CreatedBy = 2,
                      CreatedByStr = "Vedoor.Barakat@gmail.com",
                      Comment = "terrible Experience, i'm Done! Buying from this seller, #SadSeller"
                  },
                  new Review
                  {
                      ReviewId = 3,
                      ClientId = 2,
                      CreatedBy = 1,
                      CreatedByStr = "john.smith@gmail.com",
                      Comment = "Fair Experience, got what i Paid for, #FairCustomer"
                  }


              );



        }


    }
}