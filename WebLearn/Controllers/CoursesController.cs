using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLearn.Data;
using WebLearn.Models;

namespace WebLearn.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id != null)
            {
                var CourseOpen = await _context.Courses.FindAsync(id);
                return View(CourseOpen);
            }

            else
            {
                return _context.Courses != null ?
                    View(await _context.Courses.ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Courses'  is null.");

            }

        }
    }
}
        
