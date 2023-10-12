using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IBirdRepository birdRepo { get; }
        public ICageRepository cageRepo { get; }
        public IFeedingPlanRepository feedingPlanRepo { get; }
        public IFoodRepository foodRepo { get; }
        public IMealMenuRepository mealMenuRepo { get; }
        public IMenuDetailRepository menuDetailRepo { get; }
        public IPurchaseOrderRepository PORepo { get; }
        public IPurchaseOrderDetailRepository PODRepo { get; }
        public IPurchaseRequestRepository PRRepo { get; }
        public IPurchaseRequestDetailRepository PRDRepo { get; }
        public ISpieceRepository spieceRepo { get; }
        public ITaskRepository taskRepo { get; }
        public IUserRepository userRepo { get; }
        public Task<int> SaveChangeAsync();

    }
}