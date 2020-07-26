using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonthlyBillsWithDapper.Data;
using System.Threading.Tasks;

[assembly: HostingStartup(typeof(MonthlyBillsWithDapper.Areas.Identity.IdentityHostingStartup))]
namespace MonthlyBillsWithDapper.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        //public async Task<string> Get()
        //{
        //    var con = (await Startup.ConnectionString);
        //    return con;
        //}

        public void Configure(IWebHostBuilder builder)
        //public void Configure(IWebHostBuilder builder)
        {
            //var x = Get().Result;

            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MonthlyBillsWithDapperContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("Bills")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MonthlyBillsWithDapperContext>();
                services.AddControllersWithViews();
                services.AddRazorPages();
                services.AddMvc();
            });
        }

    }
}