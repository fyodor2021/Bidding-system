using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1Group26.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(ProfileReviewModel rvm) 
        {
            Client client = _context.clients.FirstOrDefault(c => c.ClientUserName == rvm.Review.CreatedByStr);
            Review reviewToAdd = new Review();
            if (client != null && rvm.Review != null)
            {
                reviewToAdd.ClientId = rvm.Review.ClientId;
                reviewToAdd.CreatedBy = client.ClientId;
                reviewToAdd.CreatedByStr = rvm.Review.CreatedByStr;
                reviewToAdd.Comment = rvm.Review.Comment;
            
            }
            _context.reviews.Add(reviewToAdd);
            _context.SaveChanges();
            return View("CommonProfile");

        }
    }
}
