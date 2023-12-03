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
    public class AttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attachments
        public async Task<IActionResult> Index()
        {
              return _context.Attachments != null ? 
                          View(await _context.Attachments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Attachments'  is null.");
        }

        // GET: Attachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachments = await _context.Attachments
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachments == null)
            {
                return NotFound();
            }

            return View(attachments);
        }

        // GET: Attachments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentId,AttachmentName,AttachmentDescription,AttachmentUrl")] Attachments attachments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attachments);
        }

        // GET: Attachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachments = await _context.Attachments.FindAsync(id);
            if (attachments == null)
            {
                return NotFound();
            }
            return View(attachments);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttachmentId,AttachmentName,AttachmentDescription,AttachmentUrl")] Attachments attachments)
        {
            if (id != attachments.AttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentsExists(attachments.AttachmentId))
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
            return View(attachments);
        }

        // GET: Attachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attachments == null)
            {
                return NotFound();
            }

            var attachments = await _context.Attachments
                .FirstOrDefaultAsync(m => m.AttachmentId == id);
            if (attachments == null)
            {
                return NotFound();
            }

            return View(attachments);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attachments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Attachments'  is null.");
            }
            var attachments = await _context.Attachments.FindAsync(id);
            if (attachments != null)
            {
                _context.Attachments.Remove(attachments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttachmentsExists(int id)
        {
          return (_context.Attachments?.Any(e => e.AttachmentId == id)).GetValueOrDefault();
        }
    }
}
