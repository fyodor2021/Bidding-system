using Assignment1Group26.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment1Group26.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _Homecontext;
        public HomeController(ApplicationDbContext ctx)
        {
            _Homecontext = ctx;
        }
        public IActionResult Index()
<<<<<<< HEAD
        {
            var bids = _Homecontext.bids.Include(c => c.Category).Include(a => a.AssetCondition).Include(u => u.Client)
                .OrderBy(b => b.BidId).ToList();   
            return View(bids);
=======

        { 

            return View();
>>>>>>> 7f1dd514ae912b7de2c2bfb9d4cec554e3db4799
        }


    }
}
