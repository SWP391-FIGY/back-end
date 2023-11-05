using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IInventoryLogService
    {
        public Task<InventoryLog> AddNewInventoryLog(InventoryLog inventoryLog);
        public Task<InventoryLog> GetInventoryLogByID(int id);
        public Task<InventoryLog> UpdateInventoryLog(InventoryLog inventoryLog, int id);
        public Task<IQueryable<InventoryLog>> GetAllInventoryLog();
        public Task<InventoryLog> DeleteInventoryLog(int id);
    }
}
