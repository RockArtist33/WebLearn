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
    public class GradeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GradeTypes
        public async Task<IActionResult> Index()
        {
              return _context.GradeTypes != null ? 
                          View(await _context.GradeTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GradeTypes'  is null.");
        }

        // GET: GradeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GradeTypes == null)
            {
                return NotFound();
            }

            var gradeTypes = await _context.GradeTypes
                .FirstOrDefaultAsync(m => m.GradeTypeId == id);
            if (gradeTypes == null)
            {
                return NotFound();
            }

            return View(gradeTypes);
        }

        // GET: GradeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeTypeId,GradeTypesName")] GradeTypes gradeTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradeTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradeTypes);
        }

        // GET: GradeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GradeTypes == null)
            {
                return NotFound();
            }

            var gradeTypes = await _context.GradeTypes.FindAsync(id);
            if (gradeTypes == null)
            {
                return NotFound();
            }
            return View(gradeTypes);
        }

        // POST: GradeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeTypeId,GradeTypesName")] GradeTypes gradeTypes)
        {
            if (id != gradeTypes.GradeTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradeTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeTypesExists(gradeTypes.GradeTypeId))
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
            return View(gradeTypes);
        }

        // GET: GradeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GradeTypes == null)
            {
                return NotFound();
            }

            var gradeTypes = await _context.GradeTypes
                .FirstOrDefaultAsync(m => m.GradeTypeId == id);
            if (gradeTypes == null)
            {
                return NotFound();
            }

            return View(gradeTypes);
        }

        // POST: GradeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GradeTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GradeTypes'  is null.");
            }
            var gradeTypes = await _context.GradeTypes.FindAsync(id);
            if (gradeTypes != null)
            {
                _context.GradeTypes.Remove(gradeTypes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeTypesExists(int id)
        {
          return (_context.GradeTypes?.Any(e => e.GradeTypeId == id)).GetValueOrDefault();
        }
    }
}
