using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class GenericRepository<Bird> : IGenericRepository<Bird> where Bird : class
    {
        protected DbSet<Bird> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<Bird>();
        }

        public async Task AddAsync(Bird bird)
        {
            await _dbSet.AddAsync(bird);
        }

        public async Task<List<Bird>> GetAllAsync(int id) => await _dbSet.ToListAsync();

        public void Update(Bird? bird)
        {
            _dbSet.Update(bird);
        }
    }
}
