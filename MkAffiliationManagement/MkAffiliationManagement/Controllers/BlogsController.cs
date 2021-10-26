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

namespace MkAffiliationManagement.Controllers
{
    public class BlogsController : Controller
    {
        private BlogDbContext _context;
        public BlogsController(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["DateSortParm"] = sortOrder == "date_desc" ? "Date" : "date_desc" ;
            var blogs = from b in _context.Blog select b;

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
            return View(await blogs.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var blog = await  _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
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
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var blog = await _context.Blog.FindAsync(id);
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
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var blog = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
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
            var blog = await _context.Blog.FindAsync(id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool BlogExists(int id)
        {
            return _context.Blog.Any(m => m.ID == id);

        }
        
    }
}
