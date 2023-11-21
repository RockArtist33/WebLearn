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
    public class UserCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserCourses
        public async Task<IActionResult> Index()
        {
              return _context.UserCourses != null ? 
                          View(await _context.UserCourses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserCourses'  is null.");
        }

        // GET: UserCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserCourses == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses
                .FirstOrDefaultAsync(m => m.UserCoursesId == id);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // GET: UserCourses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserCoursesId,UserId,CourseId")] UserCourses userCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCourses);
        }

        // GET: UserCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserCourses == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses.FindAsync(id);
            if (userCourses == null)
            {
                return NotFound();
            }
            return View(userCourses);
        }

        // POST: UserCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserCoursesId,UserId,CourseId")] UserCourses userCourses)
        {
            if (id != userCourses.UserCoursesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCoursesExists(userCourses.UserCoursesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userCourses);
        }

        // GET: UserCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserCourses == null)
            {
                return NotFound();
            }

            var userCourses = await _context.UserCourses
                .FirstOrDefaultAsync(m => m.UserCoursesId == id);
            if (userCourses == null)
            {
                return NotFound();
            }

            return View(userCourses);
        }

        // POST: UserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserCourses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserCourses'  is null.");
            }
            var userCourses = await _context.UserCourses.FindAsync(id);
            if (userCourses != null)
            {
                _context.UserCourses.Remove(userCourses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCoursesExists(int id)
        {
          return (_context.UserCourses?.Any(e => e.UserCoursesId == id)).GetValueOrDefault();
        }
    }
}
