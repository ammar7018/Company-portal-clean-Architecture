using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Data.Data.Config
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(e =>e.Id);

            builder.HasOne(e => e.applicationUser)
                .WithMany(e => e.ProjectTasks)
                .HasForeignKey(e => e.ApplicationUserId);

            builder.ToTable("ProjectTasks");
        }
    }
}
