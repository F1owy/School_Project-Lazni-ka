using BusinessLayer.Interfaces.Repository;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Repository;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var db = new AppDbContext())
{
    db.Database.EnsureCreated();

    var user = new UserEntity()
    {
        Email = "user@gmail.comn",
        Name = "User Name",
        PublicId = Guid.NewGuid()
    };

    db.Users.Add(user);
    db.SaveChanges();
}

app.Run();
