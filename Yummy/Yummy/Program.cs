using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yummy.Data;
using Yummy.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment()){
    builder.Services.AddDbContext<YummyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YummyContext")));
}
else{
    builder.Services.AddDbContext<YummyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionYummyContext")));
}


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RecipeBis}/{action=Index}/{id?}");

//app.MapRazorPages();

app.Run();
