using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IGenericRepository<Bird> where Bird : class
    {
        Task<List<Bird>> GetAllAsync(int id);
        void Update(Bird bird);
        Task AddAsync(Bird bird);
    }
}
