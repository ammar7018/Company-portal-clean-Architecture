using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.ModelVM
{
    public class DashboardVM
	{
		public IEnumerable<Project> ProjectsList { get; set; } = new List<Project>();

        public int count_freelancer { get; set; }

		public int count_NotAssigned { get; set; }
		public int count_Inprocess { get; set; }

		public int count_total { get; set; }

	}
}
