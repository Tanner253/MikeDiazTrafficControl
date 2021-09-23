using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    ID = 1,
                    Title = "This is the Title.",
                    Body = "This is the Body",
                    Image = ""

                });
        }
        public DbSet<Blog> Blog { get; set; }
    }
}


