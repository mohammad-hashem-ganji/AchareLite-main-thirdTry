
using App.Domain.Core.Adress.Entities;
using App.Domain.Core.OrderAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x=>x.Customer)
                .WithMany(x=>x.Comments)
                .HasForeignKey(x=>x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Expert)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.ExpertId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
