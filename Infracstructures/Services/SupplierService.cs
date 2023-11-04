using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Add new Supplier
        public async Task<Supplier> NewSupplier(Supplier supplier)
        {
            await _unitOfWork.SupplierRepo.Insert(supplier);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return supplier;
            else throw new Exception("Add Cage failed!!!");
        }
        #endregion

        #region Get Supplier By ID
        public async Task<Supplier> GetSupplierByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID less than 0");
            }
            var sup = await _unitOfWork.SupplierRepo.GetByIDAsync(id);
            return sup;
        }
        #endregion

        #region Get Supplier By Name
        public async Task<IQueryable<Supplier>> GetSupplierByName(string name)
        {
            var supplier = _unitOfWork.SupplierRepo.Get();
            var supName = supplier.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return supName;
        }
        #endregion

        #region Get Supplier List
        public async Task<IQueryable<Supplier>> GetSupplierList()
        {
            var supplier = _unitOfWork.SupplierRepo.Get();
            if(supplier?.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return supplier;
        }
        #endregion

        #region Update Supplier
        public async Task<Supplier> UpdateSupplier(int id, Supplier supplier)
        {
            var suppObj = await _unitOfWork.SupplierRepo.GetByIDAsync(id);
            _unitOfWork.SupplierRepo.Update(suppObj);
            var check = await _unitOfWork.SaveChangeAsync();

            if (check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return suppObj;
        }
        #endregion

        #region Delete Supplier
        public async Task<Supplier> DeleteSupplier(int id)
        {
            var suppObj = await _unitOfWork.SupplierRepo.GetByIDAsync(id);
            _unitOfWork.SupplierRepo.Delete(suppObj);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Supplier was not deleted!!!");
            }
            return null;
        }
        #endregion
    }
}
