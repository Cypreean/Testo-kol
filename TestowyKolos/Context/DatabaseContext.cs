using Microsoft.EntityFrameworkCore;
using TestowyKolos.Models;

namespace TestowyKolos.Context;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=master;User Id=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;");
    }

    public DbSet<Client> Client { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Product_Order> Product_Order { get; set; }
    public DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(new Client
        {
            IdClient = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
        });
        modelBuilder.Entity<Status>().HasData(new Status
        {
            IdStatus = 1,
            Name = "Nowe"
        });
        modelBuilder.Entity<Order>().HasData(new Order
        {
            IdOrder = 1,
            DateCreated = DateTime.Now,
            DateFinished = DateTime.Now,
            ClientID = 1,
            StatusID = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            IdProduct = 1,
            Name = "Test",
            Price = 10
        });
        modelBuilder.Entity<Product_Order>().HasData(new Product_Order
        {
            ProductID = 1,
            OrderID = 1,
            Ammount = 1
        });
    }
}