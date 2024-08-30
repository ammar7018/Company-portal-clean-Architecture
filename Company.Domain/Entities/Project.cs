using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? DriveLink { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }

        public DateOnly CreationDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? status { get; set; }
    
        public ICollection<ProjectWorker> projectWorkers { get; set; }=new List<ProjectWorker>();
        public ICollection<ApplicationUser> applicationUsers { get; set; } = new List<ApplicationUser>();

        public ICollection<Service> services { get; set; } = new List<Service>();

        public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    }
}
