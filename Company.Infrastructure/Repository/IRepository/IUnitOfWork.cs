using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IProjectRepository Project { get;  }
        public IProjectWorkerRepository ProjectWorker { get;  }
        public IServiceRepository Service { get; }
        public IUserServiceRepository UserService { get; }
        public IProjectServiceRepository ProjectService { get; }

        void Save();
    }
}
