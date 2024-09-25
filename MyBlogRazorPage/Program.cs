using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlogRazorPage.Data;
namespace MyBlogRazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MyBlogRazorPageContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyBlogRazorPageContext") ?? throw new InvalidOperationException("Connection string 'MyBlogRazorPageContext' not found.")));
            builder.Services
                .AddAuth0WebAppAuthentication(options => {
                    options.Domain = builder.Configuration["Auth0:Domain"];
                    options.ClientId = builder.Configuration["Auth0:ClientId"];
                });
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Blogs");
            });
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
