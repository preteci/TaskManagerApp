using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public interface IProjectService
    {
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<IEnumerable<Project>> GetProejctsAsync();
        Task<Project> UpdateProjectAsync(int projectId, Project updatedProject);
        Task<Project> DeleteProjectAsync(int projectId);
        Task CreateProjectAsync(Project project);
        Task<(Project, Tasks)> AddTaskToProjectAsync(int projectId, int taskId);
        Task<(Project, Tasks)> RemoveTaskFromProjectAsync(int projectId, int taskId);
        Task<(Project, IEnumerable<Tasks>)> GetAllTaskFromProjectAsync(int projectid);
    }
}