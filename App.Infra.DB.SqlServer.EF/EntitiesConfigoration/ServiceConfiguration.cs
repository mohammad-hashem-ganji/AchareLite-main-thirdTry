using App.Domain.Core.CategoryService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(40);
        }
    }
}
