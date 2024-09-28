using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using STDem0.Data;
using STDem0.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a =>
{
    a.LoginPath = "/User/login";
});
builder.Services.AddDbContext<ITIContext>(i =>
{
    i.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
});
builder.Services.AddSession(); /*a =>
{
    a.Cookie.Name = "blahblah";
}
);*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseSession();  //add , retrive data from session

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=user}/{action=login}/{id?}");

app.Run();
