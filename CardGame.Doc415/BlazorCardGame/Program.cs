using BlazorCardGame.Components;
using BlazorCardGame.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCardGame
{
    public class Program
    {

        public static void Main (string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddServerSideBlazor();


            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddDbContextFactory<CardGameDb>(
                                options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CardGameDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            builder.Services.AddScoped<Seeder>();
            var app = builder.Build();

             // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAntiforgery();
            // app.UseEndpoints();
            app.MapControllers();
            app.MapBlazorHub();
            app.UseCors(cors => cors
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );

            app.Run();
        }
    }
}
