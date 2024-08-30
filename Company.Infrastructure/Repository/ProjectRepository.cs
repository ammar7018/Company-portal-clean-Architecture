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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Project> _dbSet;
        public ProjectRepository(AppDbContext db) : base(db)
        {
            _appDbContext = db;
            _dbSet = db.Projects;
        }

        public void Update(Project obj)
        {
            _dbSet.Update(obj);
        }

    }
}
