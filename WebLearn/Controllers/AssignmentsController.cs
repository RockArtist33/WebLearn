using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLearn.Data;
using WebLearn.Models;

namespace WebLearn.Controllers
{
    public class ViewModelAA
    {
        public IEnumerable<Assignments>? Assignments { get; set; }
        public IEnumerable<Attachments>? Attachments { get; set; }

    }
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index(int id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var Assignment = _context.Assignments.Where(m => m.AssignmentId == id);
            var attachments = _context.Attachments.Where(m => m.AssignmentId == id);

            var CompositeModel = new ViewModelAA();
            CompositeModel.Assignments = Assignment;
            CompositeModel.Attachments = attachments;

            return View(CompositeModel);
        }
    }
}