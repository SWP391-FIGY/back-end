using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;
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
        public DbSet<Log> Log { get; set; }
        public DbSet<MenuDetail> MenuDetail { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set;}
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get;set; }
        public DbSet<PurchaseRequest> PurchaseRequest { get; set;}
        public DbSet<PurchaseRequestDetail> PurchaseRequestDetail { get; set ; }
        public DbSet<Species> Spiece { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Log>()
                .HasOne(e => e.Cage)
                .WithMany(e => e.Logs)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Log>()
                .HasOne(e => e.Bird)
                .WithMany(e => e.Logs)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Task>()
                .HasOne(e => e.Cage)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Task>()
                .HasOne(e => e.Bird)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
