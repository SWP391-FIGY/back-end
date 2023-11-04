using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;

        public PurchaseOrderService(IUnitOfWork unitOfWork, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
        }

        #region Create Purchase Order
        public async Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            //purchaseOrder.CreatorID = _claimsService.GetCurrentUser();
            purchaseOrder.CreateDate = _currentTime.GetCurrentTime();
            await _unitOfWork.PurchaseOrderRepo.Insert(purchaseOrder);

            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return purchaseOrder;
            }
            else throw new Exception("Create PO failed!!!");
        }
        #endregion

        #region Delete Purchase Order
        public async Task<PurchaseOrder> DeletePurchaseOrder(int id)
        {
            var po = await _unitOfWork.PurchaseOrderRepo.GetByIDAsync(id);
            _unitOfWork.PurchaseOrderRepo.Delete(po);
            var check = await _unitOfWork.SaveChangeAsync();

            if(check == 0)
            {
                throw new ArgumentException("Delete failed!!!");
            }
            return null;
        }
        #endregion

        #region Get All Purchase Order
        public async Task<IQueryable<PurchaseOrder>> GetAllPurchaseOrder()
        {
            var po = _unitOfWork.PurchaseOrderRepo.Get();
            if(po?.Count() == null) 
            {
                throw new InvalidOperationException();
            }
            return po;
        }
        #endregion

        #region Get PurchaseOrder By ID
        public async Task<PurchaseOrder> GetPurchaseOrderByID(int id)
        {
            
            var po = await _unitOfWork.PurchaseOrderRepo.GetByIDAsync(id);
            return po;
        }
        #endregion

        #region Update PurchaseOrder
        public async Task<PurchaseOrder> UpdatePurchaseOrder(int id, PurchaseOrder purchaseOrder)
        {
            var po = await _unitOfWork.PurchaseOrderRepo.GetByIDAsync(id);
            _unitOfWork.PurchaseOrderRepo.Update(po);
            var check = await _unitOfWork.SaveChangeAsync();
            if(check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return po;
        }
        #endregion
    }
}
