using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        void Remove(Project project);
        void Insert(Project project);
        Task SaveChangesAsync();
        Task<Project> GetAllTasksForProjectAsync(int projectId);

    }
}
