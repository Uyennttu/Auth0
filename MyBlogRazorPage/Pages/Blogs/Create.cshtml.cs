using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBlogRazorPage.Data;
using MyBlogRazorPage.DTO;
using MyBlogRazorPage.Mappers;

namespace MyBlogRazorPage.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly MyBlogRazorPageContext _context;

        public CreateModel(MyBlogRazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlogDTO Blog { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Convert from BlogDTO to Blog
            var blog = Blog.ToCreateBlog();

            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
