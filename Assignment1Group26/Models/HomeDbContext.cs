using Microsoft.EntityFrameworkCore;

namespace Assignment1Group26.Models
{
    public class HomeDbContext :DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }

        public DbSet<Bid> bids { get; set; }
        public DbSet<Category> categories { get; set; }
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






        }



    }
}
