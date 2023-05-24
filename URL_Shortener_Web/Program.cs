using URL_Shortener_DAL.Context;
using URL_Shortener_DAL.Repositories;
using URL_Shortener_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using URL_Shortener_BLL.Services;
using URL_Shortener_BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using URL_Shortener_DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UrlShortenerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IShortUrlService, ShortUrlService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<SignInManager<UserEntity>>();
builder.Services.AddTransient<UserManager<UserEntity>>();
builder.Services.AddIdentity<UserEntity, IdentityRole<int>>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
}).AddRoles<IdentityRole<int>>().AddEntityFrameworkStores<UrlShortenerContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy =>
    {
        policy.RequireRole("admin");
    });
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
