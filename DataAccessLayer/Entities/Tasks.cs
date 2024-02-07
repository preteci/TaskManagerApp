using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Tasks
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Task name is required.")]
        public string Name { get; set; }
        public string Decritpion { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Priority must be a positive integer.")]
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }

        public enum TaskStatus
        {
            ToDo,
            InProgress,
            Done
        }
    }
}
