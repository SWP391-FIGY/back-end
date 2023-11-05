using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infracstructures.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Add New Log
        public async Task<Log> AddNewLog(Log log)
        {
            await _unitOfWork.LogRepo.Insert(log);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return log;
            else throw new Exception("Add Log failed!!!");
        }
        #endregion

        #region Get Log By ID
        public async Task<Log> GetLogByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var log = await _unitOfWork.LogRepo.GetByIDAsync(id);
            return log;
        }
        #endregion

        #region Get Log List
        public async Task<IQueryable<Log>> GetAllLog()
        {
            var logList = _unitOfWork.LogRepo.Get();

            if (logList == null) throw new InvalidOperationException();

            return logList;
        }
        #endregion

        #region Update Log
        public async Task<Log> UpdateLog(Log log, int id)
        {

            _unitOfWork.LogRepo.Update(log);
            await _unitOfWork.SaveChangeAsync();
            return log;
        }
        #endregion

        #region Delete Log
        public async Task<Log> DeleteLog(int id)
        {
            var log = await _unitOfWork.LogRepo.GetByIDAsync(id);
            _unitOfWork.LogRepo.Delete(log);
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

