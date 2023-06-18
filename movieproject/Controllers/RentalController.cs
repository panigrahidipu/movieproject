using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace movieproject.Controllers
{
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rental
        public ActionResult Index()
        {
            var rentals = _context.RentalHeaders
                .Include(r => r.Customer)
                .Include(r => r.RentalDetails)
                .ToList();
            return View(rentals);
        }

        // GET: Rental/Create
        public ActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Movies = _context.Movies.ToList();
            return View();
        }

        // POST: Rental/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalHeader rental)
        {
            if (ModelState.IsValid)
            {
                _context.RentalHeaders.Add(rental);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Movies = _context.Movies.ToList();
            return View(rental);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnMovie(RentalDetail rentalDetail)
        {
            if (ModelState.IsValid)
            {
               
                rentalDetail.DateReturned = DateTime.Now;

              
                _context.Entry(rentalDetail).State = EntityState.Modified;
                _context.SaveChanges();

               
                return RedirectToAction("Index", "Rental");
            }

           
            return View(rentalDetail);
        }
    }
}