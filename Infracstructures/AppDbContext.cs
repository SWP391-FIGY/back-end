using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;
using Tasks = Domain.Models.Base.Tasks;

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
        public DbSet<InventoryLog> InventoryLog { get; set; }
        public DbSet<MealMenu> MealMenu { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<MenuDetail> MenuDetail { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequest { get; set; }
        public DbSet<PurchaseRequestDetail> PurchaseRequestDetail { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Tasks> Task { get; set; }
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
                .Entity<Tasks>()
                .HasOne(e => e.Cage)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<Tasks>()
                .HasOne(e => e.Bird)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<FeedingPlan>()
                .HasOne(e => e.MealMenu)
                .WithMany(e => e.FeedingPlans)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Tasks>()
                .Property(b => b.DateTime)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
