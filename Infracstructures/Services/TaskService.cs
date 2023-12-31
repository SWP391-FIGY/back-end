﻿using AutoMapper;
using Domain.Models.Base;
using Infracstructures.Interfaces;

namespace Infracstructures.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Add New Task
        public async Task<Tasks> AddNewTask(Tasks task)
        {
            await _unitOfWork.TaskRepo.Insert(task);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return task;
            else throw new Exception("Add Task failed!!!");
        }
        #endregion

        #region Get Task By ID
        public async Task<Tasks> GetTaskByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var task = await _unitOfWork.TaskRepo.GetByIDAsync(id);
            return task;
        }
        #endregion

        #region Get Task List
        public async Task<IQueryable<Tasks>> GetAllTask()
        {
            var taskList = _unitOfWork.TaskRepo.Get();

            if (taskList?.Count() == null) throw new InvalidOperationException();

            return taskList;
        }
        #endregion

        #region Update Task
        public async Task<Tasks> UpdateTask(Tasks task, int id)
        {

            _unitOfWork.TaskRepo.Update(task);
            return task;
        }
        #endregion

        #region Delete Task
        public async Task<Tasks> DeleteTask(int id)
        {
            var task = await _unitOfWork.TaskRepo.GetByIDAsync(id);
            _unitOfWork.BirdRepo.Delete(task);
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
