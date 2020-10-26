using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ParkStroiteleyMVC.Controllers;
using ParkStroiteleyMVC.Controllers.Core.HomeCore;
using ParkStroiteleyMVC.Models;
using ParkStroiteleyMVC.Models.Configs;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ParkStroiteleyMVC
{
    public class Startup
    {
        internal static Action<string> Logs = null;
        public Startup(IConfiguration configuration)
        {
            HomeController.Dispatcher = new HomeDispatcher();
            Configuration = configuration;
            Logs += Loger;
        }
        public void Loger(string message)
        {
            var main_path = Environment.CurrentDirectory + @"\Logs\" + ConfigApp.AppVersionName + "_" + ConfigApp.AppVersion + DateTime.Now.Date.Day.ToString() + "." + DateTime.Now.Date.Month.ToString() + @"\";
            if (Directory.Exists(main_path))
            {
                var file_path = $"{main_path}LOGAT{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}.txt";

                File.AppendAllText(file_path, message);
            }
            else
            {
                Directory.CreateDirectory(main_path);
                Loger(message);
            }
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddDbContextPool<HomeContext>(
               options => options.UseMySql(ConfigDatabase.ConnectionString,
               mySqlOptions =>
               {
                   mySqlOptions.ServerVersion(new Version(5, 6, 45), ServerType.MySql);
               }
           ));
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
