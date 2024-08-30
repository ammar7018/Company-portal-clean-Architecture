using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }

        public string? ApplicationUserId { get; set; }
        public ApplicationUser? applicationUser { get; set; }

        public int ProjectId { get; set; }
        public Project project { get; set; }
    }
}
