using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;

namespace BusinessLogicLayer
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITasksRepository _tasksRepository;

        public ProjectService(IProjectRepository projectRepository, ITasksRepository tasksRepository)
        {
            _projectRepository = projectRepository;
            _tasksRepository = tasksRepository; 
        }

        public async Task<IEnumerable<Project>> GetProejctsAsync()
        {
             return await _projectRepository.GetProjectsAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            return project;
        }

        public async Task CreateProjectAsync(Project project)
        {
            _projectRepository.Insert(project);
            await _projectRepository.SaveChangesAsync();
        }

        // function to update project
        public async Task<Project> UpdateProjectAsync(int projectId, Project updatedProject)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if(project is null)
            {
                return project;
            }
            //updating project
            project.Name = updatedProject.Name;
            project.StartDate = updatedProject.StartDate;
            project.CompletionDate = updatedProject.CompletionDate;
            project.Priority = updatedProject.Priority;
            project.Status = updatedProject.Status;

            await _projectRepository.SaveChangesAsync();

            return project;
        }
        
        // function to delete project
        public async Task<Project> DeleteProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if(project is null)
            {
                return project;
            }
            _projectRepository.Remove(project);
            await _projectRepository.SaveChangesAsync();
            return project;
        }

        // function to add task to project
        public async Task<(Project,Tasks)> AddTaskToProjectAsync(int projectId, int taskId)
        {
            var project = await _projectRepository.GetAllTasksForProjectAsync(projectId);
            var task = await _tasksRepository.GetTaskByIdAsync(taskId);
            if (project == null || task == null)
            {
                return (project, task);
            }
            project.Tasks.Add(task);
            await _tasksRepository.SaveChangesAsync();
            return (project, task);
            
        }

        // function to remove task from project
        public async Task<(Project, Tasks)> RemoveTaskFromProjectAsync(int projectId, int taskId)
        {
            var project = await _projectRepository.GetAllTasksForProjectAsync(projectId);
            var task = await _tasksRepository.GetTaskByIdAsync(taskId);
            if (project == null || task == null)
            {
                return (project, task);
            }
            project.Tasks.Remove(task);
            await _tasksRepository.SaveChangesAsync();
            return (project, task);
        }

        public async Task<(Project, IEnumerable<Tasks>)> GetAllTaskFromProjectAsync(int projectid)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectid);
            var tasks = await _projectRepository.GetAllTasksForProjectAsync(projectid);
            if(project == null)
            {
                return (project, null);
            }
            return (project, tasks.Tasks);
        }
    }
}
