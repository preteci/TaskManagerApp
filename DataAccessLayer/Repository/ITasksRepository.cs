using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    public interface ITasksRepository
    {
        Task<Tasks> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<Tasks>> GetTasksAsync();
        void Remove(Tasks task);
        void Insert(Tasks task);
        Task SaveChangesAsync();
    }
}