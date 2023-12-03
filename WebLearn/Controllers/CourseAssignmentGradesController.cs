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
    public class CourseAssignmentGradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseAssignmentGradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseAssignmentGrades
        public async Task<IActionResult> Index()
        {
              return _context.CourseAssignmentGrades != null ? 
                          View(await _context.CourseAssignmentGrades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CourseAssignmentGrades'  is null.");
        }

        // GET: CourseAssignmentGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseAssignmentGrades == null)
            {
                return NotFound();
            }

            var courseAssignmentGrades = await _context.CourseAssignmentGrades
                .FirstOrDefaultAsync(m => m.CAGId == id);
            if (courseAssignmentGrades == null)
            {
                return NotFound();
            }

            return View(courseAssignmentGrades);
        }

        // GET: CourseAssignmentGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseAssignmentGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CAGId,UserId,CourseId,CourseOnly,AssignmentId,GradeId")] CourseAssignmentGrades courseAssignmentGrades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseAssignmentGrades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseAssignmentGrades);
        }

        // GET: CourseAssignmentGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseAssignmentGrades == null)
            {
                return NotFound();
            }

            var courseAssignmentGrades = await _context.CourseAssignmentGrades.FindAsync(id);
            if (courseAssignmentGrades == null)
            {
                return NotFound();
            }
            return View(courseAssignmentGrades);
        }

        // POST: CourseAssignmentGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CAGId,UserId,CourseId,CourseOnly,AssignmentId,GradeId")] CourseAssignmentGrades courseAssignmentGrades)
        {
            if (id != courseAssignmentGrades.CAGId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseAssignmentGrades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseAssignmentGradesExists(courseAssignmentGrades.CAGId))
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
            return View(courseAssignmentGrades);
        }

        // GET: CourseAssignmentGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseAssignmentGrades == null)
            {
                return NotFound();
            }

            var courseAssignmentGrades = await _context.CourseAssignmentGrades
                .FirstOrDefaultAsync(m => m.CAGId == id);
            if (courseAssignmentGrades == null)
            {
                return NotFound();
            }

            return View(courseAssignmentGrades);
        }

        // POST: CourseAssignmentGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseAssignmentGrades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseAssignmentGrades'  is null.");
            }
            var courseAssignmentGrades = await _context.CourseAssignmentGrades.FindAsync(id);
            if (courseAssignmentGrades != null)
            {
                _context.CourseAssignmentGrades.Remove(courseAssignmentGrades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseAssignmentGradesExists(int id)
        {
          return (_context.CourseAssignmentGrades?.Any(e => e.CAGId == id)).GetValueOrDefault();
        }
    }
}
