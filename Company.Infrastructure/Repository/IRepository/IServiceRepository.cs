﻿using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Infrastructure.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        void Update(Service obj);
    }
}
