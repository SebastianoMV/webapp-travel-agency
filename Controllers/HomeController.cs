using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly PgContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Package> packages = _context.Packages.ToList();
            return View(packages);
        }

        public IActionResult Create()
        {
            Package newPackage = new Package();      

            return View(newPackage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Package form)
        {
            if (!ModelState.IsValid)
            {
                
                return View("Create", form);
            }
            _context.Add(form);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Package package = _context.Packages.Where(pack => pack.Id == id).First();
            if (package == null)
            {
                return NotFound($"Il pachetto con id {id} non è stato trovato");
            }
            else
            {
                return View("Details", package);
            }
        }

        public IActionResult Update(int id)
        {

            Package package = _context.Packages.Where(pack => pack.Id == id).First();
         

            return View(package);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Package form)
        {
            if (!ModelState.IsValid)
            {
                form.Id = id;
                
                return View("Update", form);
            }
            Package package = _context.Packages.Where(pack => pack.Id == id).First();
            package.Name = form.Name;
            package.Description = form.Description;
            package.Price = form.Price;
            package.Days = form.Days;
            package.Image = form.Image;
           
            _context.Packages.Update(package);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Package package = _context.Packages.Where(pack => pack.Id == id).First();
            _context.Packages.Remove(package);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}