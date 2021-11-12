using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Areas.Identity.Data;
using MkAffiliationManagement.Data;
using MkAffiliationManagement.Models;
using MkAffiliationManagement.Models.Interfaces;

namespace MkAffiliationManagement.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogManager _context;
        public BlogsController(IBlogManager context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["DateSortParm"] = sortOrder == "date_desc" ? "Date" : "date_desc" ;
            
            var blogs = await _context.GetBlogs();

            switch (sortOrder)
            {
                case "Date":
                    blogs = blogs.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    blogs = blogs.OrderByDescending(s => s.Date);
                    break;
                default:
                    blogs = blogs.OrderBy(s => s.ID);
                    break;
            }
            return View(blogs);
        }

        public async Task<IActionResult> Details(int id)
        {
            
            var blog = await _context.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [Authorize(Roles = ApplicationRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Title, Body, Image, Date")] Blog blog)
        {
            if (ModelState.IsValid)
            {
               await _context.CreateBlog(blog);
               
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            
            var blog = await _context.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Title, Body, Image, Date")] Blog blog)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateBlog(id,blog);
                    
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!BlogExists(blog.ID))
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
            return View(blog);
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Delete (int id)
        {
            
            var blog = await _context.DeleteBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        //Post: Blogs/Delete/5
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.GetBlog(id);
            await _context.DeleteBlogFR(id);
            
            return RedirectToAction(nameof(Index));
        }
        
        private bool BlogExists(int id)
        {
            return _context.BlogExists(id);

        }
        
    }
}
