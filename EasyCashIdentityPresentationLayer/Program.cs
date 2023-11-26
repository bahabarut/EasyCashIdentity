using EasyCashIdentityBusinessLayer.ValidationRules.AppUserValidationRules;
using EasyCashIdentityDataAccessLayer.Concrete;
using EasyCashIdentityDTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityEntityLayer.Concrete;
using EasyCashIdentityPresentationLayer.Models;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//context ayarlarý
builder.Services.AddDbContext<Context>();
//ýdentity iþlemleri için - error describer özelleþtirilmiþ hatalar için
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityErrors>();


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
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
