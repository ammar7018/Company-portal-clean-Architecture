using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class ProjectWorker
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public string Role { get; set; }
        public int Salary { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
