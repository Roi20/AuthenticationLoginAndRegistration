using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Data;
using AuthenticationLoginAndRegistration.Data.Entities;
using AuthenticationLoginAndRegistration.EmailService;
using AuthenticationLoginAndRegistration.Repositories;
using AuthenticationLoginAndRegistration.Services;
using AuthenticationLoginAndRegistration.TodoService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var EMAIL_SETTINGS_CONFIG = "EmailSettings";

var config = builder.Configuration;

builder.Services.Configure<EmailSettings>(config.GetSection(EMAIL_SETTINGS_CONFIG));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
