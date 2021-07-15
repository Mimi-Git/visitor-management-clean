using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(v => v.ArrivalTime)
                .IsRequired();

            builder.Property(v => v.ArrivalTime)
                 .IsRequired();

            builder.Property(v => v.ArrivalTime)
                .IsRequired();

            builder.Property(v => v.ArrivalTime)
                .IsRequired();
        }
    }
}