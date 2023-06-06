using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Filtters;
using MVCDemo.Models;
using MVCDemo.Repository;

namespace MVCDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//

            // Add services to the container. (IOC Container) ServierProvider//Day 8
            //1) built in service - alread register "Configuration"
            
            //2) built in service - not register
            builder.Services.AddControllersWithViews(options=>
            {
                //global filter
                //options.Filters.Add(new HandelErrorAttribute());
            });
                //.AddSessionStateTempDataProvider();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            builder.Services.AddDbContext<ITIEntity>(options =>
            {
                //options.UseSqlServer("Data Source=.;Initial Catalog=ITISohag;Integrated Security=True;Encrypt=False");
                options.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            });
            builder.Services.AddAuthentication()//CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            //3) custom service  - not register
            builder.Services.AddScoped<IEmployeeRespoitory, EmployeeRepository>();//REgister 
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();



            var app = builder.Build();
            #region Custom Middlewares
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("Middleware 1\n");
            //    await next();
            //    await httpContext.Response.WriteAsync("Middleware  1_1\n");
            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("Middleware 2\n");
            //    await next();
            //    await httpContext.Response.WriteAsync("Middleware 2_2\n");
            //});
            //app.Run(async (httpcontext) =>
            //{
            //    await httpcontext.Response.WriteAsync("Terminate\n");
            //});
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("Middleware 3\n");
            //    await next();
            //});
            #endregion
            #region Built in Middleware 
            // Configure the HTTP request pipeline. //Day 2 middler
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");//first and last
            }
            app.UseStaticFiles();//extension .css ,js ,jpg ,html ==>wwwroot
            
            app.UseSession();

            app.UseRouting();//match request with specific route 
            
            app.UseAuthentication();//option
            //authontication middlew
            app.UseAuthorization();//permission
            //Nameing Convention Route
            //r1 litter
            //{name}|{age} placeholder
            //{age?} optional placeholder
            //{age:int} constraint placholder
            //{action} {contoller}
            //app.MapControllerRoute("Rout1", "r1/{name}/{age:int:range(10,50)}",
            //    new
            //    {
            //        controller="Routing",
            //        action="Index"
            //    }
            //    );
            //app.MapControllerRoute("Rout2", "r2",
            //    new
            //    {
            //        controller = "Routing",
            //        action = "Index2"
            //    }
            //    );
            //r1/index2 - r1/index - r1
            app.MapControllerRoute("Rout2", "r1/{action=Index}",
                new
                {
                    controller = "Routing"
                }
                );
          
            //--------------DEfault
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");//define route
            
            #endregion
            app.Run();//
        }
    }
}