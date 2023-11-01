using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;

        public PurchaseRequestService(IUnitOfWork unitOfWork, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
        }

        #region Create PurchaseRequest
        public async Task<PurchaseRequest> CreatePurchaseRequest(PurchaseRequest purchaseRequest)
        {
            purchaseRequest.DateTime = _currentTime.GetCurrentTime();
            await _unitOfWork.PurchaseRequestRepo.Insert(purchaseRequest);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return purchaseRequest;
            else throw new Exception("Create failed!!!");
        }
        #endregion

        #region Delete PurchaseRequest
        public async Task<PurchaseRequest> DeletePurchaseRequest(int id)
        {
            var pr = await _unitOfWork.PurchaseRequestRepo.GetByIDAsync(id);
            _unitOfWork.PurchaseRequestRepo.Delete(pr);

            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0) throw new ArgumentException("Delete failed!!!");
            return null;
        }
        #endregion

        #region Get All PurchaseRequest
        public async Task<IQueryable<PurchaseRequest>> GetAllPurchaseRequest()
        {
            var pr = _unitOfWork.PurchaseRequestRepo.Get();
            if (pr?.Count() == null) throw new InvalidOperationException();
            return pr;
        }
        #endregion

        #region Get PurchaseRequest By ID
        public async Task<PurchaseRequest> GetPurchaseRequestByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID less than 0");
            }
            var pr = await _unitOfWork.PurchaseRequestRepo.GetByIDAsync(id);
            return pr;
        }
        #endregion

        #region Update PurchaseRequest
        public async Task<PurchaseRequest> UpdatePurchaseRequest(int id, PurchaseRequest purchaseRequest)
        {
            var pr = await _unitOfWork.PurchaseRequestRepo.GetByIDAsync(id);
            _unitOfWork.PurchaseRequestRepo.Update(pr);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0) throw new ArgumentException("Update failed!!!");
            return pr;
        }
        #endregion
    }
}
