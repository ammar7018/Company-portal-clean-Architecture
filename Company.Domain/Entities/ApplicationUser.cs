using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public ICollection<ProjectWorker> projectWorkers { get; set; } = new List<ProjectWorker>();
        public ICollection<Project> projects { get; set; } = new List<Project>();


        //m-to-m service-user
        public ICollection<Service> Services { get; set; } = new List<Service>();

        public ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    }
}
