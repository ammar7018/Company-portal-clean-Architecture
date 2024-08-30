using Company.Infrastructure.Data;
using Company.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Config
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
           builder.HasKey(x => x.Id);

            builder.HasMany(e => e.applicationUsers)
                .WithMany(e => e.Services)
                .UsingEntity<UserService>();

            builder.ToTable("Services");

            builder.HasData(SeedData.ServiceData());
        }
    }
}
