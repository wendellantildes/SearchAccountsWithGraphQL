using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SearchAccountsWithGraphQL.Api.Business;
using SearchAccountsWithGraphQL.Api.Infra;
using SearchAccountsWithGraphQL.Api.Model;

namespace SearchAccountsWithGraphQL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

            services.AddScoped<AccountService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AccountService accountService)
        {
            var anAccount = new Account(100, AccountsType.Checking, "234678", DateTime.Now.AddYears(-1), "10012");
           
            accountService.Insert(anAccount);

            var blockedAccount = new Account(200450, AccountsType.Checking, "236689", DateTime.Now.AddYears(-1).AddDays(-40).AddHours(-3), "33333012");
            blockedAccount.Block();
            accountService.Insert(blockedAccount);

            var closedAccount = new Account(300567, AccountsType.Savings, "23178", DateTime.Now.AddYears(-3).AddMonths(-2).AddHours(-2), "9800111");
            closedAccount.Close(DateTime.Now);
            accountService.Insert(closedAccount);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
