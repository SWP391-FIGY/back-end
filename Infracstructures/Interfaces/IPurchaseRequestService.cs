using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IPurchaseRequestService
    {
        public Task<PurchaseRequest> CreatePurchaseRequest(PurchaseRequest purchaseRequest);
        public Task<IQueryable<PurchaseRequest>> GetAllPurchaseRequest();
        public Task<PurchaseRequest> GetPurchaseRequestByID(int id);
        public Task<PurchaseRequest> UpdatePurchaseRequest(int id, PurchaseRequest purchaseRequest);
        public Task<PurchaseRequest> DeletePurchaseRequest(int id);
    }
}
