using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class InventoryLogService : IInventoryLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Add New InventoryLog
        public async Task<InventoryLog> AddNewInventoryLog(InventoryLog inventoryLog)
        {
            await _unitOfWork.InventoryLogRepo.Insert(inventoryLog);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return inventoryLog;
            else throw new Exception("Add Inventory Log failed!!!");
        }
        #endregion

        #region Get InventoryLog By ID
        public async Task<InventoryLog> GetInventoryLogByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var inventoryLog = await _unitOfWork.InventoryLogRepo.GetByIDAsync(id);
            return inventoryLog;
        }
        #endregion

        #region Get InventoryLog List
        public async Task<IQueryable<InventoryLog>> GetAllInventoryLog()
        {
            var inventoryLogList = _unitOfWork.InventoryLogRepo.Get();

            if (inventoryLogList == null) throw new InvalidOperationException();

            return inventoryLogList;
        }
        #endregion

        #region Update InventoryLog
        public async Task<InventoryLog> UpdateInventoryLog(InventoryLog inventoryLog, int id)
        {

            _unitOfWork.InventoryLogRepo.Update(inventoryLog);
            await _unitOfWork.SaveChangeAsync();
            return inventoryLog;
        }
        #endregion

        #region Delete InventoryLog
        public async Task<InventoryLog> DeleteInventoryLog(int id)
        {
            var inventoryLog = await _unitOfWork.InventoryLogRepo.GetByIDAsync(id);
            _unitOfWork.LogRepo.Delete(inventoryLog);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Delete Failed!!!");
            }
            return null;
        }
        #endregion
    }
}
