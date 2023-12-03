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
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var CourseOpen = await _context.Courses.FirstOrDefaultAsync(m => m.course_Id == id);
            if (CourseOpen == null)
            {
                return NotFound();
            }

            return View(CourseOpen);
        }
    }
}
        
