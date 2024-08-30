using Company.Infrastructure.Data;
using Company.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public IProjectRepository Project { get; private set; }

        public IProjectWorkerRepository ProjectWorker { get; private set; }

        public IServiceRepository Service { get; private set; }

        public IUserServiceRepository UserService { get; private set; }

        public IProjectServiceRepository ProjectService { get; private set; }


        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;

            Service = new ServiceRepository(_db);
            Project = new ProjectRepository(_db);
            ProjectService =new ProjectServiceRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
