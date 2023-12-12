using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebLearn.Data;
using System;
using System.Linq;
using WebLearn.Models;

namespace WebLearn.Controllers;



    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;
                }
            context.Courses.AddRange(
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                },
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                },
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                },
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                },
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                },
                new Courses
                {
                    course_name = "Test 1",
                    course_description = "Description",
                    front_image = null,
                    created_at = DateTime.Now
                }
            );
            context.Assignments.AddRange(
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 1
                },
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 2
                },
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 3
                },
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 4
                },
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 5
                },
                new Assignments
                {
                    AssignmentName = "Default Assignment",
                    AssignmentDescription = "Description",
                    AttachmentId = 6
                }
                );
            context.Attachments.AddRange(
                new Attachments
                {
                    AssignmentId= 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                },
                new Attachments
                {
                    AssignmentId = 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                },
                new Attachments
                {
                    AssignmentId = 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                },
                new Attachments
                {
                    AssignmentId = 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                },
                new Attachments
                {
                    AssignmentId = 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                },
                new Attachments
                {
                    AssignmentId = 1,
                    AttachmentName = "Default Attachment",
                    AttachmentDescription = "Description",
                    AttachmentUrl = null,
                }
                );
            context.SaveChanges();
            }
        }
    }

