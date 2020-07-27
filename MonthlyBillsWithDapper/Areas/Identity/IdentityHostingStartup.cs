using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonthlyBillsWithDapper.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.BrowserLink;
using MonthlyBillsWithDapper.Areas.Identity;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<string> Get()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            string secret = (await kv.GetSecretAsync("https://trkeyvault3.vault.azure.net/", "connectionstring")).Value;
            return secret;
        }

        public void Configure(IWebHostBuilder builder)
        //public void Configure(IWebHostBuilder builder)
        {
            //var x = Get().Result;
            var ConnectionString = Get();

            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MonthlyBillsWithDapperContext>(async options => options.UseSqlServer(await ConnectionString));
                //options.UseSqlServer(context.Configuration.GetConnectionString("Bills")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MonthlyBillsWithDapperContext>();
                services.AddControllersWithViews();
                services.AddRazorPages();
                services.AddMvc();
            });
        }

    }
}