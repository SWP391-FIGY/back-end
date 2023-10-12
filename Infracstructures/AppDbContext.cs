using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = Domain.Models.Base.Task;

namespace Infracstructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Bird> Bird { get; set; }
        public DbSet<Cage> Cage { get; set; }
        public DbSet<FeedingPlan> FeedingPlan { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<MealMenu> MealMenu { get; set; }
        public DbSet<MenuDetail> MenuDetail { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set;}
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get;set; }
        public DbSet<PurchaseRequest> PurchaseRequest { get; set;}
        public DbSet<PurchaseRequestDetail> PurchaseRequestDetail { get; set ; }
        public DbSet<Spiece> Spiece { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
    }
}
