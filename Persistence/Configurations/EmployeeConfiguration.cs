using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(v => v.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Email)
                .IsRequired();

            builder.Property(e => e.Department)
                .HasMaxLength(100);
        }
    }
}