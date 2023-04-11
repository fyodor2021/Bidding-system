using Assignment1Group26.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Assignment1Group26.Service;
using Stripe;
using Assignment1Group26.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IEmailSender, EmailSender>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options =>
{
    options.AppendTrailingSlash = true;
    options.LowercaseUrls= true;
    
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("guestLogin",policy => policy.RequireClaim("user","guest"));
});
//email configration
var configuration = builder.Configuration;
var emailconfig = configuration.GetSection("email");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<StripeSetting>(configuration.GetSection("StripeKeys"));

var app = builder.Build();
StripeConfiguration.ApiKey = configuration.GetSection("StripeKeys")["SecreteKey"];

///StripeConfiguration.SetApiKey(configuration.GetSection("StripeKeys")["SecreteKey"]);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
