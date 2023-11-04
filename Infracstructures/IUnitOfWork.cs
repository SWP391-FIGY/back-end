using Domain.Models.Base;
using Infracstructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures
{
    public interface IUnitOfWork
    {
        GenericRepository<Bird> BirdRepo { get; }
        GenericRepository<Cage> CageRepo { get; }
        GenericRepository<FeedingPlan> FeedingPlanRepo { get; }
        GenericRepository<Food> FoodRepo { get; }
        GenericRepository<Log> LogRepo { get; }
        GenericRepository<MealMenu> MealMenuRepo { get; }
        GenericRepository<MenuDetail> MenuDetailRepo { get; }
        GenericRepository<PurchaseOrder> PurchaseOrderRepo { get; }
        GenericRepository<PurchaseOrderDetail> PurchaseOrderDetailRepo { get; }
        GenericRepository<PurchaseRequest> PurchaseRequestRepo { get; }
        GenericRepository<PurchaseRequestDetail> PurchaseRequestDetailRepo { get; }
        GenericRepository<Species> SpeciesRepo { get; }
        GenericRepository<Supplier> SupplierRepo { get; }
        GenericRepository<User> UserRepo { get; }
        GenericRepository<Tasks> TaskRepo { get; }
        Task<int> SaveChangeAsync();
    }
}
