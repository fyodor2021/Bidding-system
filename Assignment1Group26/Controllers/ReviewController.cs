using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

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

            var clients = _context.clients.ToList();
            Client client = _context.clients.FirstOrDefault(c => c.ClientUserName == rvm.Review.CreatedByStr);
            Review reviewToAdd = new Review();
            if (client != null && rvm.Review != null)
            {
                reviewToAdd.ClientId = rvm.Review.ClientId;
                reviewToAdd.CreatedBy = client.ClientId;
                reviewToAdd.CreatedByStr = rvm.Review.CreatedByStr;
                reviewToAdd.Comment = rvm.Review.Comment;
                reviewToAdd.Rating = rvm.Review.Rating;
            
            }
            _context.reviews.Add(reviewToAdd);
            _context.SaveChanges();
            var tables = new ProfileReviewModel
            {
                Reviews = _context.reviews.Where(r => r.ClientId == rvm.Review.ClientId).ToList(),
                Client = _context.clients.FirstOrDefault(C => C.ClientId == rvm.Review.ClientId)

            };
            return View("../../Views/Profile/CommonProfile", tables);

        }
        public IActionResult Delete(int id) 
        {
            Review reviewToDelete = _context.reviews.FirstOrDefault(r => r.ReviewId == id);
            Client client = _context.clients.FirstOrDefault(c => c.ClientId == reviewToDelete.ClientId);
            if (reviewToDelete != null)
            {
                _context.Remove(reviewToDelete);
                _context.SaveChanges();
            }
            var tables = new ProfileReviewModel
            {
                Reviews = _context.reviews.Where(r => r.ClientId == client.ClientId).ToList(),
                Client = client

            };
            return View("../../Views/Profile/CommonProfile", tables);
        }
    }
}
