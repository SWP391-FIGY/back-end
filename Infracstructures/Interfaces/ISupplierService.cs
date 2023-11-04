using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface ISupplierService
    {
        public Task<Supplier> NewSupplier(Supplier supplier);
        public Task<Supplier> GetSupplierByID(int id);
        public Task<IQueryable<Supplier>> GetSupplierByName(string name);
        public Task<IQueryable<Supplier>> GetSupplierList();
        public Task<Supplier> UpdateSupplier(int id, Supplier supplier);
        public Task<Supplier> DeleteSupplier(int id);
    }
}
