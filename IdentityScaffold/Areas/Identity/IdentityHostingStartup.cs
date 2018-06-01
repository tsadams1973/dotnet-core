using System;
using IdentityScaffold.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityScaffold.Areas.Identity.IdentityHostingStartup))]
namespace IdentityScaffold.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityScaffoldIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityScaffoldIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<IdentityScaffoldIdentityDbContext>();
            });
        }
    }
}