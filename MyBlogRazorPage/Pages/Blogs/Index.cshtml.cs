using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogRazorPage.Data;
using MyBlogRazorPage.Model;

namespace MyBlogRazorPage.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogRazorPageContext _context;

        public IndexModel(MyBlogRazorPageContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog.ToListAsync();
        }
    }
}
