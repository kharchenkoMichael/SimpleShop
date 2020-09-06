using Microsoft.EntityFrameworkCore;
using SimpleShop.Models;

namespace SimpleShop.Repositories
{
  public class ShopContext : DbContext
  {
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public ShopContext(DbContextOptions<ShopContext> opt)
      :base(opt)
    {
      //Database.EnsureDeleted();
      //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ProductCategory>().HasData(
        new ProductCategory[]
        {
          new ProductCategory { Id=1, Name="Category1"},
          new ProductCategory { Id=2, Name="Category2"},
          new ProductCategory { Id=3, Name="Category3"},
          new ProductCategory { Id=4, Name="Category4"},
          new ProductCategory { Id=5, Name="Category5"},
          new ProductCategory { Id=6, Name="Category6"}
        });

      modelBuilder.Entity<Product>().HasData(
        new Product[]
        {
          new Product { Id=1, Name="Product1", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=2, Name="Product2", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=3, Name="Product3", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=4, Name="Product4", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=5, Name="Product5", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=6, Name="Product6", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=7, Name="Product7", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=8, Name="Product8", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=9, Name="Product9", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=10, Name="Product10", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=11, Name="Product11", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=12, Name="Product12", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 1},
          new Product { Id=13, Name="Product13", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 2},
          new Product { Id=14, Name="Product14", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 2},
          new Product { Id=15, Name="Product15", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 2},
          new Product { Id=16, Name="Product16", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 2},
          new Product { Id=17, Name="Product17", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 3},
          new Product { Id=18, Name="Product18", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 3},
          new Product { Id=19, Name="Product19", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 3},
          new Product { Id=20, Name="Product20", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 4},
          new Product { Id=21, Name="Product21", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 4},
          new Product { Id=22, Name="Product22", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 4},
          new Product { Id=23, Name="Product23", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 5},
          new Product { Id=24, Name="Product24", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 5},
          new Product { Id=25, Name="Product25", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 5},
          new Product { Id=26, Name="Product26", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 5},
          new Product { Id=27, Name="Product27", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 6},
          new Product { Id=28, Name="Product28", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 6},
          new Product { Id=29, Name="Product29", Price = 100, NumberOfItemsInStock = 100, ProductCategoryId = 6},
        });
    }
  }
}
