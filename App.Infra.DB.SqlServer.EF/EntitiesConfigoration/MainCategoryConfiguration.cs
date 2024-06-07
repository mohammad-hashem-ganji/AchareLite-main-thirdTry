using App.Domain.Core.CategoryService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class MainCategoryConfiguration : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(35);

            #region seed data
            builder.HasData(new MainCategory { Id = 1, Title = "تمیزکاری" });
            builder.HasData(new MainCategory { Id = 2, Title = "ساختمان" });
            builder.HasData(new MainCategory { Id = 3, Title = "تعمیرات اشیا" });
            builder.HasData(new MainCategory { Id = 4, Title = "اسباب کسی" });
            builder.HasData(new MainCategory { Id = 5, Title = "خودورو" });
            builder.HasData(new MainCategory { Id = 6, Title = "سلامت و زیبایی" });
            #endregion
        }
    }
}
