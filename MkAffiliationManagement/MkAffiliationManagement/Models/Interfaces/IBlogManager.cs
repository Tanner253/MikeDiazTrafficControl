using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models.Interfaces
{
    public interface IBlogManager
    {
        Task CreateBlog(Blog blog);
        Task UpdateBlog(int id, Blog blog);
        Task<Blog> DeleteBlog(int id);
        Task DeleteBlogFR(int id);
        Task<Blog> GetBlog(int id);
        Task<IEnumerable<Blog>> GetBlogs();
        bool BlogExists(int id);
    }
}
