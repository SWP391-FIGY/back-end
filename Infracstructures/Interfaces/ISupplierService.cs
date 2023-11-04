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
        Task<Supplier> NewSupplier(Supplier supplier);
        Task<Supplier> GetSupplierByID(int id);
        Task<IQueryable<Supplier>> GetSupplierByName(string name);
        Task<IQueryable<Supplier>> GetSupplierList();
        Task<Supplier> UpdateSupplier(int id, Supplier supplier);
        Task<Supplier> DeleteSupplier(int id);
    }
}
