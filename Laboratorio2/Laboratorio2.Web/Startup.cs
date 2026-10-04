using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Laboratorio2.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ES2.1: Injecting appSettings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // ES2.2: DECOMMENTARE LA SEGUENTE ISTRUZIONE PER CONFIGURARE LA SESSION
            //services.AddSession();

            var builder = services.AddMvc();
                //.AddSessionStateTempDataProvider(); // ES2.2: CONFIGURA IL TEMPDATA

#if DEBUG
            builder.AddRazorRuntimeCompilation();
#endif

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Features/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Views/Shared/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // ES2.2: DECOMMENTARE LA SEGUENTE ISTRUZIONE PER CONFIGURARE LA SESSION
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                // ES1: DECOMMENTARE LE SEGUENTI ISTRUZIONI 1 PER VOLTA PER VERIFICARE

                //endpoints.MapControllerRoute("Pianifica", "Pianifica/Tasks");
                //endpoints.MapAreaControllerRoute("pippo", "Pianifica", "Pianifica/{controller}/{action=Index}/{id?}");
                //endpoints.MapAreaControllerRoute("Pianifica", "Pianifica", "Pianifica/{controller=Test}/{action=Index}");
                endpoints.MapControllerRoute("pluto", "{controller=Login}/{action=Login}/{id?}");

                // ES4: DEFINIRE LE ROTTE PER I VARI CONTROLLERS

                // ES5: DEFINIRE UNA ROTTA PER LE NEWS

                // ES2: DECOMMENTARE LA SEGUENTE ISTRUZIONE
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
