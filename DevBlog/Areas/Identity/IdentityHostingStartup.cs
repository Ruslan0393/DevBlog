using System;
using DevBlog.Areas.Identity.Data;
using DevBlog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DevBlog.Areas.Identity.IdentityHostingStartup))]
namespace DevBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DevBlogContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DevBlogContextConnection")));

                services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DevBlogContext>();
            });
        }
    }
}