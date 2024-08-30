using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.Data.Config
{
    public class ProjectWorkerConfiguration : IEntityTypeConfiguration<ProjectWorker>
    {
        public void Configure(EntityTypeBuilder<ProjectWorker> builder)
        {
            builder.HasKey(e => new {e.ProjectId,e.UserId});


            builder.ToTable("ProjectWorkers");
        }
    }
}
