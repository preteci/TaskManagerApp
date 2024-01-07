using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Tasks>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == taskId);
            return task;
        }

        public void Insert(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Remove(Tasks task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
