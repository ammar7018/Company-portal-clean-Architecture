using Company.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Data
{
    public static class SeedData
    {
        public static List<Service> ServiceData()
        {
            return new List<Service>()
            {
                new Service()
                {
                    Id = 1,
                    Name = "Backend",
                    Description = "Backend is Responsible for The back Integration of Web Application"
                },
                new Service()
                {
                    Id = 2,
                    Name = "Frontend",
                    Description = "Frontend is Responsible for The Interface of Web Application"
                }
            };
        }

        public static List<Project> ProjectData()
        {
            return new List<Project>()
            {
                new Project()
                {
                    Id = 1,
                    DriveLink = "https://drive.google.com/samplelink1",
                    Name = "AI Research Project",
                    Description = "Researching AI applications in healthcare.",
                    Cost = 150000,
                    CreationDate = new DateTime(2023, 1, 15),
                    EndDate = new DateTime(2024, 1, 15),
                },
                new Project()
                {
                    Id = 2,
                    DriveLink = "https://drive.google.com/samplelink2",
                    Name = "Web Development Project",
                    Description = "Developing an e-commerce website.",
                    Cost = 75000,
                    CreationDate = new DateTime(2023, 5, 20),
                    EndDate = new DateTime(2024, 2, 28)
                }
            };
        }
    }
}
