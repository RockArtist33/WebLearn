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
    public class UserCalendarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCalendarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserCalendars
        public async Task<IActionResult> Index()
        {
              return _context.UserCalendar != null ? 
                          View(await _context.UserCalendar.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserCalendar'  is null.");
        }

        // GET: UserCalendars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserCalendar == null)
            {
                return NotFound();
            }

            var userCalendar = await _context.UserCalendar
                .FirstOrDefaultAsync(m => m.UserCalendarId == id);
            if (userCalendar == null)
            {
                return NotFound();
            }

            return View(userCalendar);
        }

        // GET: UserCalendars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCalendars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserCalendarId,EventId,UserId")] UserCalendar userCalendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCalendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCalendar);
        }

        // GET: UserCalendars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserCalendar == null)
            {
                return NotFound();
            }

            var userCalendar = await _context.UserCalendar.FindAsync(id);
            if (userCalendar == null)
            {
                return NotFound();
            }
            return View(userCalendar);
        }

        // POST: UserCalendars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserCalendarId,EventId,UserId")] UserCalendar userCalendar)
        {
            if (id != userCalendar.UserCalendarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCalendar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCalendarExists(userCalendar.UserCalendarId))
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
            return View(userCalendar);
        }

        // GET: UserCalendars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserCalendar == null)
            {
                return NotFound();
            }

            var userCalendar = await _context.UserCalendar
                .FirstOrDefaultAsync(m => m.UserCalendarId == id);
            if (userCalendar == null)
            {
                return NotFound();
            }

            return View(userCalendar);
        }

        // POST: UserCalendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserCalendar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserCalendar'  is null.");
            }
            var userCalendar = await _context.UserCalendar.FindAsync(id);
            if (userCalendar != null)
            {
                _context.UserCalendar.Remove(userCalendar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCalendarExists(int id)
        {
          return (_context.UserCalendar?.Any(e => e.UserCalendarId == id)).GetValueOrDefault();
        }
    }
}
