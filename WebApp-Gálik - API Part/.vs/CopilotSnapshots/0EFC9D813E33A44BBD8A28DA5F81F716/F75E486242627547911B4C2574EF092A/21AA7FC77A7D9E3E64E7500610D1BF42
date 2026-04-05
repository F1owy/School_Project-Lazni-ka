using DataLayer.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
   {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductImageEntity> ProductImages { get; set; }
     public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
      public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
 if (!optionsBuilder.IsConfigured)
            {
        optionsBuilder.UseSqlite("Data Source=app.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
      .HasOne(u => u.Cart)
      .WithOne(c => c.User)
     .HasForeignKey<CartEntity>(c => c.UserId);

     modelBuilder.Entity<UserEntity>()
     .HasMany(u => u.Reviews)
  .WithOne(r => r.User)
    .HasForeignKey(r => r.UserId);

  modelBuilder.Entity<OrderEntity>()
     .HasOne(o => o.User)
.WithMany()
    .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<ProductEntity>()
         .HasMany(p => p.Images)
       .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<ProductEntity>()
  .HasMany(p => p.CartItems)
    .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId);

 modelBuilder.Entity<ProductEntity>()
.HasMany(p => p.Reviews)
.WithOne(r => r.Product)
         .HasForeignKey(r => r.ProductId);

modelBuilder.Entity<CartEntity>()
      .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)
    .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<OrderEntity>()
             .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

   modelBuilder.Entity<OrderItemEntity>()
  .HasOne(oi => oi.Product)
       .WithMany()
            .HasForeignKey(oi => oi.ProductId);
      }
    }
}
