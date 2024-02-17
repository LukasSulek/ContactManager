using ECoding_MVC_app.DatabaseContext;
using ECoding_MVC_app.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ECoding_MVC_app.Mapping;
using ECoding_MVC_app.Factories;

namespace ECoding_MVC_app
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Register DB context
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register IAppDbContext service.
            builder.Services.AddScoped<IAppDbContext, AppDbContext>();

            // Register auto-mapper service to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Register contact service to the container.
            builder.Services.AddTransient(typeof(IContactService), typeof(ContactService));


            // Register contact factory to the container.
            builder.Services.AddTransient(typeof(IContactFactory), typeof(ContactFactory));


            // Add services to the container.
            builder.Services.AddControllersWithViews();



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contacts}/{action=Index}/{id?}");


            app.Run();
        }
    }
}