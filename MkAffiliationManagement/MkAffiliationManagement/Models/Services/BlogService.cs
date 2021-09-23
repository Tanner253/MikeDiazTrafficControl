using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Data;
using MkAffiliationManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models.Services
{
    public class BlogService : IBlogManager
    {
        private BlogDbContext _context;
        public BlogService(BlogDbContext context)
        {
            _context = context;
        }
        public bool BlogExists(int id)
        {
            return _context.Blog.Any(m => m.ID == id);
        }

        public async Task CreateBlog(Blog blog)
        {
            _context.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> DeleteBlog(int id)
        {
            var selectedBlog = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
            return selectedBlog;
        }

        public async Task DeleteBlogFR(int id)
        {
            var selectedBlog = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
            _context.Remove(selectedBlog);
            await _context.SaveChangesAsync();
        }
       

        public async Task<Blog> GetBlog(int id)
        {
            return await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blog.ToListAsync();
        }

        public async Task UpdateBlog(int id, [Bind("ID,Title, Body, Image")]Blog blog)
        {
            _context.Update(blog);
            await _context.SaveChangesAsync();
        }
    }
}
