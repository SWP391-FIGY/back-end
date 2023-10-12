using Application;
using Application.Repositories;

namespace Infracstructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IBirdRepository _birdRepo;
        private readonly ICageRepository _cageRepo;
        private readonly IFeedingPlanRepository _feedingPlanRepo;
        private readonly IFoodRepository _foodRepo;
        private readonly IMealMenuRepository _mealMenuRepo;
        private readonly IMenuDetailRepository _menuDetailRepo;
        private readonly IPurchaseOrderRepository _PORepo;
        private readonly IPurchaseOrderDetailRepository _PODRepo;
        private readonly IPurchaseRequestRepository _PRRepo;
        private readonly IPurchaseRequestDetailRepository _PRDRepo;
        private readonly ISpieceRepository _spieceRepo;
        private readonly ITaskRepository _taskRepo;
        private readonly IUserRepository _userRepo;
        
        
        public UnitOfWork(AppDbContext context, IBirdRepository birdRepository, ICageRepository cageRepository,
            IFeedingPlanRepository feedingPlanRepository, IFoodRepository foodRepository,
            IMealMenuRepository mealMenuRepository, IMenuDetailRepository menuDetailRepository,
            IPurchaseOrderRepository PORepository, IPurchaseOrderDetailRepository PODRepository,
            IPurchaseRequestRepository PRRepository, IPurchaseRequestDetailRepository PRDRepository,
            ISpieceRepository spieceRepository, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _context = context;
            _birdRepo = birdRepository;
            _cageRepo = cageRepository;
            _foodRepo = foodRepository;
            _feedingPlanRepo = feedingPlanRepository;
            _mealMenuRepo = mealMenuRepository;
            _menuDetailRepo = menuDetailRepository;
            _PORepo = PORepository;
            _PRRepo = PRRepository;
            _PRDRepo = PRDRepository;
            _taskRepo = taskRepository;
            _userRepo = userRepository;
            _spieceRepo = spieceRepository;
        }

        public IBirdRepository birdRepo => _birdRepo;

        public ICageRepository cageRepo => _cageRepo;

        public IFeedingPlanRepository feedingPlanRepo => _feedingPlanRepo;

        public IFoodRepository foodRepo => _foodRepo;

        public IMealMenuRepository mealMenuRepo => _mealMenuRepo;

        public IMenuDetailRepository menuDetailRepo => _menuDetailRepo;

        public IPurchaseOrderRepository PORepo => _PORepo;

        public IPurchaseOrderDetailRepository PODRepo => _PODRepo;

        public IPurchaseRequestRepository PRRepo => PRRepo;

        public IPurchaseRequestDetailRepository PRDRepo => _PRDRepo;

        public ISpieceRepository spieceRepo => _spieceRepo;

        public ITaskRepository taskRepo => _taskRepo;

        public IUserRepository userRepo => _userRepo;

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
