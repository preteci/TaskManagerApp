using DataAccessLayer.Entities;

namespace WebApi.Controllers
{
    public class ProjectFilter
    {
        DateTime? startDate {  get; set; }
        DateTime? endDate { get; set; }
        int? priority { get; set; }
        ProjectStatus status { get; set; }
    }
}
