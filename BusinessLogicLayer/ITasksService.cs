using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int taskId);
        Task<Tasks> UpdateTaskAsync(int taskId, Tasks task);
        Task<Tasks> DeleteTaskAsync(int taskId);
        Task CreateTaskAsync(Tasks task);
    }
}