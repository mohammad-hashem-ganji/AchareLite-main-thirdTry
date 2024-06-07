using App.Domain.Core.OrderAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(b => b.Id);


            builder.HasOne(x => x.Order)
               .WithMany(x => x.Bids)
               .HasForeignKey(x => x.OrderId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
