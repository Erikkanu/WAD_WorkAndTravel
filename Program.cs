using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;
using WAD_WorkAndTravel.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRegistrationFormService, RegistrationFormService>();
builder.Services.AddScoped<IGalleryPostService, GalleryPostService>();


builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRegistrationFormRepository, RegistrationFormRepository>();
builder.Services.AddScoped<IGalleryPostRepository, GalleryPostRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContext<WAT_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WorkAndTravelDb")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Add roles support
    .AddEntityFrameworkStores<WAT_Context>();

// Register AuthService
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login";  // Redirect to the login page if not authenticated
//    });
//builder.Services.AddScoped<AuthService>();
//builder.Services.AddScoped<UserService>();

// Enable session management
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// --- SEED ROLES AND USERS ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // 1. Ensure roles exist
    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // 2. Create admin user
    var adminEmail = "admin@example.com";
    var adminPassword = "Admin123!"; // Use a strong password
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var adminUser = new User { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    // 3. Create normal user
    var userEmail = "user@example.com";
    var userPassword = "User123!"; // Use a strong password
    if (await userManager.FindByEmailAsync(userEmail) == null)
    {
        var normalUser = new User { UserName = userEmail, Email = userEmail, EmailConfirmed = true };
        var result = await userManager.CreateAsync(normalUser, userPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(normalUser, "User");
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Create users on app startup for testing
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var userService = services.GetRequiredService<UserService>();

//    try
//    {
//        // Create some test users
//        userService.CreateUser("user1", "password123");
//        userService.CreateUser("user2", "password456");
//        userService.CreateUser("user3", "password789");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Error seeding users: " + ex.Message);
//    }
//}

app.UseHttpsRedirection();
app.UseRouting();

// Enable session middleware
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
