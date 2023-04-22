using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Repository.Database;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.Models;
using Microsoft.AspNetCore.Identity;
using HRBMSWEBAPP.Service;
using HRBMSWEBAPP.Repository.DbRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HRBMSDBCONTEXT>();
builder.Services.AddScoped<HRBMSDBCONTEXT, HRBMSDBCONTEXT>();
builder.Services.AddScoped<IBookingDBRepository, BookingDBRepository>();
builder.Services.AddScoped<IRoomDBRepository, RoomDBRepository>();
builder.Services.AddScoped<IRoomCatDBRepository, RoomCategoryDBRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountDBRepository, AccountDbRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HRBMSDBCONTEXT>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


//app.Automigrate();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
