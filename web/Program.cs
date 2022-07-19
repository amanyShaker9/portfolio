using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(Options =>Options.UseSqlServer(builder.Configuration.GetConnectionString("MyPortfolioDB")));
builder.Services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=home}/{action=index}/{id?}");

app.Run();
