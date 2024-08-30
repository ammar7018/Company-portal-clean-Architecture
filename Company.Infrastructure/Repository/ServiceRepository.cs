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
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Service> _dbSet;
        public ServiceRepository(AppDbContext db) : base(db)
        {
            _appDbContext = db;
            _dbSet = db.Services;
        }

        public void Update(Service obj)
        {
            _dbSet.Update(obj);
        }
    }
}
