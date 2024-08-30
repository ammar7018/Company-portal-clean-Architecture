using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> applicationUsers { get; set; } = new List<ApplicationUser>();

        public ICollection<Project> projects { get; set; } = new List<Project>();


    }
}
