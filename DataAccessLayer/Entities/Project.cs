using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime StartDate { get; set; }

    
        public DateTime? CompletionDate { get; set; }

        public ProjectStatus Status { get; set; }

        public List<Tasks>? Tasks { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Priority must be a positive integer.")]
        public int Priority { get; set; }


    }

    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
