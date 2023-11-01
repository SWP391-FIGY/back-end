using Domain.Models.Base;

namespace Infracstructures.Interfaces
{
    public interface IPurchaseOrderService
    {
        public Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrder purchaseOrder);
        public Task<IQueryable<PurchaseOrder>> GetAllPurchaseOrder();
        public Task<PurchaseOrder> GetPurchaseOrderByID(int id);
        public Task<PurchaseOrder> UpdatePurchaseOrder(int id, PurchaseOrder purchaseOrder);
        public Task<PurchaseOrder> DeletePurchaseOrder(int id);
    }
}
