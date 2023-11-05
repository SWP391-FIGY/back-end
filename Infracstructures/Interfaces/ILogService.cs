using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface ILogService
    {
        public Task<Log> AddNewLog(Log log);
        public Task<Log> GetLogByID(int id);
        public Task<Log> UpdateLog(Log log, int id);
        public Task<IQueryable<Log>> GetAllLog();
        public Task<Log> DeleteLog(int id);
    }
}
