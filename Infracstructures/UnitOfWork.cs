using Application;
using Application.Repositories;
using Domain.Models.Base;
using Infracstructures.Repositories;

namespace Infracstructures
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext _context;
        private GenericRepository<Bird> _birdRepo;
        private GenericRepository<Cage> _cageRepo;
        private GenericRepository<FeedingPlan> _feedingPlanRepo;
        private GenericRepository<Food> _foodRepo;
        private GenericRepository<Log> _logRepo;
        private GenericRepository<MealMenu> _mealMenuRepo;
        private GenericRepository<MenuDetail> _menuDetailRepo;
        private GenericRepository<PurchaseOrder> _purchaseOrderRepo;
        private GenericRepository<PurchaseOrderDetail> _purchaseOrderDetailRepo;
        private GenericRepository<PurchaseRequest> _purchaseRequestRepo;
        private GenericRepository<PurchaseRequestDetail> _purchaseRequestDetailRepo;
        private GenericRepository<Species> _speciesRepo;
        private GenericRepository<Domain.Models.Base.Task> _taskRepo;
        private GenericRepository<User> _userRepo;
        
        
        
        public GenericRepository<Bird> BirdRepo
        {
            get
            {
                if (this._birdRepo == null)
                {
                    this._birdRepo = new GenericRepository<Bird>(_context);
                }
                return _birdRepo;
            }
        }

        public GenericRepository<Cage> CageRepo
        {
            get
            {
                if (this._cageRepo == null)
                {
                    this._cageRepo = new GenericRepository<Cage>(_context);
                }
                return _cageRepo;
            }
        }

        public GenericRepository<FeedingPlan> FeedingPlanRepo
        {
            get
            {
                if (this._feedingPlanRepo == null)
                {
                    this._feedingPlanRepo = new GenericRepository<FeedingPlan>(_context);
                }
                return _feedingPlanRepo;
            }
        }

        public GenericRepository<Food> FoodRepo
        {
            get
            {
                if (this._foodRepo == null)
                {
                    this._foodRepo = new GenericRepository<Food>(_context);
                }
                return _foodRepo;
            }
        }

        public GenericRepository<Log> LogRepo
        {
            get
            {
                if (this._logRepo == null)
                {
                    this._logRepo = new GenericRepository<Log>(_context);
                }
                return _logRepo;
            }
        }
        public GenericRepository<MealMenu> MealMenuRepo
        {
            get
            {
                if (this._mealMenuRepo == null)
                {
                    this._mealMenuRepo = new GenericRepository<MealMenu>(_context);
                }
                return _mealMenuRepo;
            }
        }

        public GenericRepository<MenuDetail> MenuDetailRepo
        {
            get
            {
                if (this._menuDetailRepo == null)
                {
                    this._menuDetailRepo = new GenericRepository<MenuDetail>(_context);
                }
                return _menuDetailRepo;
            }
        }
        public GenericRepository<PurchaseOrder> PurchaseOrderRepo
        {
            get
            {
                if (this._purchaseOrderRepo == null)
                {
                    this._purchaseOrderRepo = new GenericRepository<PurchaseOrder>(_context);
                }
                return _purchaseOrderRepo;
            }
        }

        public GenericRepository<PurchaseOrderDetail> PurchaseOrderDetailRepo
        {
            get
            {
                if (this._purchaseOrderDetailRepo == null)
                {
                    this._purchaseOrderDetailRepo = new GenericRepository<PurchaseOrderDetail>(_context);
                }
                return _purchaseOrderDetailRepo;
            }
        }

        public GenericRepository<PurchaseRequest> PurchaseRequestRepo
        {
            get
            {
                if (this._purchaseRequestRepo == null)
                {
                    this._purchaseRequestRepo = new GenericRepository<PurchaseRequest>(_context);
                }
                return _purchaseRequestRepo;
            }
        }
        public GenericRepository<PurchaseRequestDetail> PurchaseRequestDetailRepo
        {
            get
            {
                if (this._purchaseRequestDetailRepo == null)
                {
                    this._purchaseRequestDetailRepo = new GenericRepository<PurchaseRequestDetail>(_context);
                }
                return _purchaseRequestDetailRepo;
            }
        }
        public GenericRepository<Species> SpeciesRepo
        {
            get
            {
                if (this._speciesRepo == null)
                {
                    this._speciesRepo = new GenericRepository<Species>(_context);
                }
                return _speciesRepo;
            }
        }

        public GenericRepository<Domain.Models.Base.Task> TaskRepo
        {
            get
            {
                if (this._taskRepo == null)
                {
                    this._taskRepo = new GenericRepository<Domain.Models.Base.Task>(_context);
                }
                return _taskRepo;
            }
        }

        public GenericRepository<User> UserRepo
        {
            get
            {
                if (this._userRepo == null)
                {
                    this._userRepo = new GenericRepository<User>(_context);
                }
                return _userRepo;
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
