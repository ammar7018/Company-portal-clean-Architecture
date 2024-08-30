using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.Data.Config
{
    public class ProjectServiceConfiguration : IEntityTypeConfiguration<ProjectService>
    {
        public void Configure(EntityTypeBuilder<ProjectService> builder)
        {
            builder.HasKey(e => new { e.ProjectId, e.ServiceId });


            builder.ToTable("ProjectServices");
        }
    }
}
