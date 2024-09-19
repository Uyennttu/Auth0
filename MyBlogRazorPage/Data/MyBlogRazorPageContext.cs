using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlogRazorPage.Model;

namespace MyBlogRazorPage.Data
{
    public class MyBlogRazorPageContext : DbContext
    {
        public MyBlogRazorPageContext (DbContextOptions<MyBlogRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<MyBlogRazorPage.Model.Blog> Blog { get; set; } = default!;
    }
}
