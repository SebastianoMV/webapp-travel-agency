using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        PgContext _context;
        public UserController()
        {
            _context = new PgContext();
        }

        [HttpGet]
        public IActionResult Get(string? str)
        {
            IQueryable<Package> packages= _context.Packages;

            if (str != null)
            {
                packages = _context.Packages.Where(package => package.Name.ToLower().Contains(str.ToLower()) || package.Description.ToLower().Contains(str.ToLower()));

            }
            else
            {
                packages = _context.Packages;
            }

            return Ok(packages.ToList<Package>());
        }
    }
}
