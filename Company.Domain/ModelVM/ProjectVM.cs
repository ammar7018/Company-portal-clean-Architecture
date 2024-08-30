using Company.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.ModelVM
{
    public class ProjectVM
    {
        public Project project { get; set; }


        public IEnumerable<SelectListItem>? ServiceList { get; set; }
        public ICollection<int> servicesID { get; set; } = new List<int>();


    }
}
