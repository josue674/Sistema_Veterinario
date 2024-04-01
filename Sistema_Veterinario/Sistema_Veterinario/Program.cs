using Microsoft.EntityFrameworkCore;
using Sistema_Veterinario.DAL;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Sistema_VeterinarioDbContext>(options => options.UseSqlServer("name=ConnRSDB").LogTo(Console.WriteLine, LogLevel.Information));

//***IDENTITY***
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<UsuarioApplication, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultUI();

builder.Services.AddRazorPages();
//***IDENTITY***


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//***IDENTITY***
app.UseAuthentication();
app.UseAuthorization();
//***IDENTITY***

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//***IDENTITY***
app.MapRazorPages();
//***IDENTITY***

app.Run();
