using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            IQueryable<Package> packages= _context.Packages;



            return Ok(packages.ToList<Package>());
        }
    }
}
