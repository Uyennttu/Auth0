using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogRazorPage.Data;
using MyBlogRazorPage.Model;

namespace MyBlogRazorPage.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly MyBlogRazorPageContext _context;

        public DetailsModel(MyBlogRazorPageContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
