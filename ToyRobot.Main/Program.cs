using ToyRobot.BusinessLogic.BusinessWrapper;
using ToyRobot.BusinessLogic.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IBusinessWrapper, BusinessWrapper>();

builder.Services.Configure<AppSettingsDTO>(
    builder.Configuration.GetSection("TableDimension"));

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
    pattern: "{controller=Position}/{action=Index}/{id?}");

app.Run();
