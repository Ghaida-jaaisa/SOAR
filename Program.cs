using Microsoft.EntityFrameworkCore;
using WebCourse_FinalProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddSession();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CourseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CourseContextStr")));
builder.Services.AddDbContext<PersonContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PersonContextStr")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
