using AccessData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using sniiv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sniiv.Models;
using Microsoft.AspNetCore.Identity;
using Elastic.Apm.NetCoreAll;

namespace sniiv
{
    public class Startup
    {
        //private readonly string _MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SqlHelper.connectionString = ConfigurationExtensions.GetConnectionString(this.Configuration, "ConexionDB");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => { options.AllowEmptyInputInBodyModelBinding = true; });

            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ConexionDB")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>();
                
            services.AddControllersWithViews();
            services.AddLocalization();
            services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Reporte/Login";
                options.AccessDeniedPath = "/Reporte/Login";
                options.SlidingExpiration = true;
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);


            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {

                    Title = "API's para Desarrolladores",

                });
            });
            //services.AddCors(options => {
            /*options.AddPolicy(name: _MyCors, builder =>
            {
                builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                //builder.WithOrigins("https://localhost:44380").AllowAnyHeader().AllowAnyMethod();
                //builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                //builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            });
        });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catálogo de API's");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //ELK LOGS
            //app.UseAllElasticApm(Configuration);
            app.UseStaticFiles();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseRequestLocalization("es-MX");
            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Reporte}/{action=Indicadores}/{id?}");
                    //pattern: "{controller=Cubo}/{action=Insus}/{id?}");
                    pattern: "{controller=Inicio}/{action=Acerca_de}/{id?}");
            });

            //app.UseCors(_MyCors);
        }
    }
}
