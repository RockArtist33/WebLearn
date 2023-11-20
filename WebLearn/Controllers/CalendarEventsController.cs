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
    public class CalendarEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendarEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CalendarEvents
        public async Task<IActionResult> Index()
        {
              return _context.CalendarEvents != null ? 
                          View(await _context.CalendarEvents.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CalendarEvents'  is null.");
        }

        // GET: CalendarEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CalendarEvents == null)
            {
                return NotFound();
            }

            var calendarEvents = await _context.CalendarEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (calendarEvents == null)
            {
                return NotFound();
            }

            return View(calendarEvents);
        }

        // GET: CalendarEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalendarEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,EventDescription,EventDate")] CalendarEvents calendarEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendarEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendarEvents);
        }

        // GET: CalendarEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalendarEvents == null)
            {
                return NotFound();
            }

            var calendarEvents = await _context.CalendarEvents.FindAsync(id);
            if (calendarEvents == null)
            {
                return NotFound();
            }
            return View(calendarEvents);
        }

        // POST: CalendarEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,EventDescription,EventDate")] CalendarEvents calendarEvents)
        {
            if (id != calendarEvents.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendarEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarEventsExists(calendarEvents.EventId))
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
            return View(calendarEvents);
        }

        // GET: CalendarEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalendarEvents == null)
            {
                return NotFound();
            }

            var calendarEvents = await _context.CalendarEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (calendarEvents == null)
            {
                return NotFound();
            }

            return View(calendarEvents);
        }

        // POST: CalendarEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalendarEvents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CalendarEvents'  is null.");
            }
            var calendarEvents = await _context.CalendarEvents.FindAsync(id);
            if (calendarEvents != null)
            {
                _context.CalendarEvents.Remove(calendarEvents);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarEventsExists(int id)
        {
          return (_context.CalendarEvents?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
