using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace TaskManagerV1.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProejctsAsync();
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            if(project == null)
            {
                return NotFound("Invalid ID for project");
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project newProject)
        {
            await _projectService.CreateProjectAsync(newProject);
            return Ok(newProject);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var project = await _projectService.DeleteProjectAsync(projectId);
            if(project is null)
            {
                return NotFound("Invalid ID");
            }
            return Ok($"Project {projectId} has been deleted.");
        }

        [HttpPost("{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> AddTaskToProjectAsync(int projectId, int taskId)
        {
            var result = await _projectService.AddTaskToProjectAsync(projectId, taskId);
            if(result.Item1 == null)
            {
                return NotFound("Invlaid ID for project");
            }
            else if(result.Item2 == null)
            {
                return NotFound("Invalid ID for task");
            }
            return Ok($"Task ${taskId} has been added to project ${projectId}");
        }

        [HttpDelete("{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> RemoveTaskFromProjectAsync(int projectId, int taskId)
        {
            var result = await _projectService.RemoveTaskFromProjectAsync(projectId, taskId);
            if (result.Item1 == null)
            {
                return NotFound("Invlaid ID for project");
            }
            else if (result.Item2 == null)
            {
                return NotFound("Invalid ID for tasks");
            }
            return Ok($"Task {taskId} has been removed from project {projectId}");
        }
        [HttpGet("{projectid}/tasks")]
        public async Task<IActionResult> GetAllTaskFromProjectAsync(int projectid)
        {
            var result = await _projectService.GetAllTaskFromProjectAsync(projectid);
            if(result.Item1 == null)
            {
                return NotFound("Invalid Project ID");
            }
            return Ok(result.Item2);
        }

        [HttpPatch("{projectId}")]
        public async Task<IActionResult> UpdateProjectAsync(int projectId, Project updatedProject)
        {
            var project = await _projectService.UpdateProjectAsync(projectId, updatedProject);
            if(project is null)
            {
                return NotFound("Invalid Project ID");
            }
            return Ok(project);
        }
        
    }
}
