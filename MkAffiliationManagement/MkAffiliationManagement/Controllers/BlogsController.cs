using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Data;

namespace MkAffiliationManagement.Controllers
{
    public class BlogsController : Controller
    {
        private BlogDbContext _context;
        public BlogsController(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog.ToListAsync());
        }
    }
}
