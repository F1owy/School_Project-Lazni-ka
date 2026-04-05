using BusinessLayer.Interfaces.Repository;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Repository;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });


builder.Services.AddAuthentication("Auth")
    .AddCookie("Auth",options => 
    {
        options.Cookie.Name = "AuthCookie";
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });
    
    
    

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
 context.Database.EnsureCreated();

    if (!context.Users.Any())
    {
   var testUser = new UserEntity
{
       PublicId = Guid.NewGuid(),
  Name = "Test User",
       Email = "test@test.sk",
     Password = "test123",
       Role = RoleEnum.User
  };
   context.Users.Add(testUser);
       context.SaveChanges();

        var cart = new CartEntity
     {
  PublicId = Guid.NewGuid(),
         UserId = testUser.id
  };
   context.Carts.Add(cart);
     context.SaveChanges();
    }

    if (!context.Products.Any())
    {
        var products = new List<ProductEntity>
        {
         new ProductEntity
            {
         PublicId = Guid.NewGuid(),
     Name = "Sony FX6 Cinema Camera",
 Description = "Profesionálna kinematografická kamera Sony FX6 s full-frame senzorom",
Price = 6299f,
   Category = CategoryEnum.Cameras,
   StockAmount = 5
  },
           new ProductEntity
            {
       PublicId = Guid.NewGuid(),
     Name = "Canon RF 24-70mm f/2.8L",
   Description = "Profesionálny objektív Canon RF 24-70mm f/2.8L IS USM",
           Price = 2899f,
       Category = CategoryEnum.Lenses,
  StockAmount = 10
          }
  };

   context.Products.AddRange(products);
  context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
