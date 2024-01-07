using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }
        
        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<Project> GetAllTasksForProjectAsync(int projectId)
        {
            return await _dbContext.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public void Remove(Project project)
        {
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
        }

        public void Insert(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
