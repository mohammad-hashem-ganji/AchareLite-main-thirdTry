using App.Domain.Core.OrderAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Title).HasMaxLength(30);

        }
    }
}
