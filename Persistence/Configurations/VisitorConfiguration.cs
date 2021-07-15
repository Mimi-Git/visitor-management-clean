using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
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
        }
    }
}