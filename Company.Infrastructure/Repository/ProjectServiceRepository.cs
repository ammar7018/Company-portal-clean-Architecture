using Company.Domain.Entities;
using Company.Infrastructure.Data;
using Company.Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository
{
    public class ProjectServiceRepository : Repository<ProjectService>, IProjectServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<ProjectService> _dbSet;
        public ProjectServiceRepository(AppDbContext db) : base(db)
        {
            _appDbContext = db;
            _dbSet = db.ProjectServices;
        }


        public void Update(ProjectService obj)
        {
            _dbSet.Update(obj);
        }
    }
}
