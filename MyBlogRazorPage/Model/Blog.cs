namespace MyBlogRazorPage.Model;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string Author { get; set; }
}