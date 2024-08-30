using Company.Infrastructure.Data;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(e => e.applicationUsers)
                .WithMany(e => e.projects)
                .UsingEntity<ProjectWorker>();

            builder.HasMany(e => e.services)
                    .WithMany(e => e.projects)
                    .UsingEntity<ProjectService>();

            builder.HasMany(e => e.ProjectTasks)
                   .WithOne(e => e.project)
                   .HasForeignKey(e=>e.ProjectId);


            builder.ToTable("Projects");


            builder.HasData(SeedData.ProjectData());
        }
    }
}
