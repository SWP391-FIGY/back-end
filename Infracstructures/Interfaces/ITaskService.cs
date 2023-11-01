using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface ITaskService
    {
        public Task<Tasks> AddNewTask(Tasks task);
        public Task<Tasks> GetTaskByID(int id);
        public Task<Tasks> UpdateTask(Tasks task, int id);
        public Task<IQueryable<Tasks>> GetAllTask();
    }
}
