using Blazor.Memory.Components;
using Blazor.Memory.Data;
using Blazor.Memory.Models;
using Blazor.Memory.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(opt => { opt.DetailedErrors = true; });

builder.Services.AddRazorPages();

builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<SettingsService>();

builder.Services.AddDbContext<MemoryContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("The connection string was not found."))); ;
builder.Services.AddSingleton<Settings>(s =>
{
    using var scope = s.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MemoryContext>();
    var settings = context.Set<Settings>().FirstOrDefault();

    if (settings == null)
    {
        settings = new Settings { CardsNumber = 18 };
        context.Set<Settings>().Add(settings);
        context.SaveChanges();
    }

    return settings;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MemoryContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
