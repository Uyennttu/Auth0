using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogRazorPage.Data;
using MyBlogRazorPage.Model;

namespace MyBlogRazorPage.Pages.Blogs
{
    public class DeleteModel : PageModel
    {
        private readonly MyBlogRazorPageContext _context;

        public DeleteModel(MyBlogRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog != null)
            {
                Blog = blog;
                _context.Blog.Remove(Blog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
