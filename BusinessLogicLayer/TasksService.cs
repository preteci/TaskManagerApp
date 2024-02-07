using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using DataAccessLayer.Entities;
using System.Runtime.InteropServices;

namespace BusinessLogicLayer
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepository;

        public TasksService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Tasks>> GetTasksAsync()
        {
            return await _taskRepository.GetTasksAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int taskId)
        {
            var task = await _taskRepository.GetTaskByIdAsync(taskId);
            return task;
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            _taskRepository.Insert(task);
            await _taskRepository.SaveChangesAsync();
        }
        
        public async Task<Tasks> DeleteTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetTaskByIdAsync(taskId);
            if(task is null)
            {
                return task;
            }
            _taskRepository.Remove(task);
            await _taskRepository.SaveChangesAsync();
            return task;
            
        }

        public async Task<Tasks> UpdateTaskAsync(int taskId, Tasks updatedTask)
        {
            var task = await _taskRepository.GetTaskByIdAsync(taskId);
            if(task is null)
            {
                return task;
            }
            task.Status = updatedTask.Status;
            task.Decritpion = updatedTask.Decritpion;
            task.Name = updatedTask.Name;
            task.Priority = updatedTask.Priority;

            await _taskRepository.SaveChangesAsync();

            return task;
        }  
    }
}
