using Microsoft.EntityFrameworkCore;

namespace Assignment1Group26.Models
{
    public class HomeDbContext :DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }

    }
}
