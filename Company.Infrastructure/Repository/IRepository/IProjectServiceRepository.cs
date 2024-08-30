using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository.IRepository
{
    public interface IProjectServiceRepository:IRepository<ProjectService>
    {
        void Update(ProjectService obj);
    }
}
