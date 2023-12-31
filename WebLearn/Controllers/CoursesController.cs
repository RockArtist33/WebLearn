﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebLearn.Data;
using WebLearn.Models;

namespace WebLearn.Controllers
{
    public class ViewModelCA
    {
        public IEnumerable<Courses>? Courses { get; set; }
        public IEnumerable<Assignments>? Assignments { get; set; }
    
    }
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

            var CourseOpen = _context.Courses.Where(m => m.course_Id == id);
            var AssignmentsOpen = _context.Assignments.Where(m => m.CourseId == id);
            
            var CompositeModel = new ViewModelCA();
            CompositeModel.Courses = CourseOpen;
            CompositeModel.Assignments = AssignmentsOpen;


            if (CompositeModel.Courses == null || CompositeModel.Assignments == null)
            {
                return NotFound();
            }

            return View(CompositeModel);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("course_Id","course_name","course_description","front_image","created_at")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                courses.created_at = DateTime.Now;
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("localhost:7231");
        }
    }
}
        
