using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly UnitContext _context;

        public UnitController(UnitContext context)
        {
            _context = context;

            if (_context.Units.Count() == 0)
            {
                _context.Units.Add(new Unit { UnitName = "Web Application Development", UnitCode = "FIT5032" });
                _context.Units.Add(new Unit { UnitName = "Programming Foundations in Java", UnitCode = "FIT9131" });
                _context.Units.Add(new Unit { UnitName = "Introduction to Databases", UnitCode = "FIT9132" });
                _context.SaveChanges();
            }
        }

        // GET: api/unit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            return await _context.Units.ToListAsync();
        }

        // GET: api/unit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(long id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
                return NotFound();

            return unit;
        }
    }
}
