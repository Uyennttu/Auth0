using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBlogRazorPage.Data;
using MyBlogRazorPage.DTO;
using MyBlogRazorPage.Mappers;

namespace MyBlogRazorPage.Pages.Blogs
{
    public class EditModel : PageModel
    {
        private readonly MyBlogRazorPageContext _context;

        public EditModel(MyBlogRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogDTO Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //This will return the Blog model
            var blog = await _context.Blog.FirstOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            //Convert founded Blog to BlogDTO model
            var blogDtoModel = blog.ToBlogDto();
            Blog = blogDtoModel;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the existing Blog entity from the database
            var blogEntity = await _context.Blog.FirstOrDefaultAsync(b => b.Id == id);

            if (blogEntity == null)
            {
                return NotFound();
            }

            // Update the matching properties from the BlogDTO to the existing Blog entity
            blogEntity.Title = Blog.Title;
            blogEntity.Content = Blog.Content;
            blogEntity.Author = Blog.Author;

            // Update the entity state to modified
            _context.Attach(blogEntity).State = EntityState.Modified;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
