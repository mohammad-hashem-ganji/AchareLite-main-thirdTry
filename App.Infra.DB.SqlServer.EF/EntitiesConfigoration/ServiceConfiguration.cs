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
            #region seed data
            builder.HasData(new Service { Id = 1, SubCategoryId = 1 , Title = "سرویس عادی نظافت" });
            builder.HasData(new Service { Id = 2, SubCategoryId = 1 , Title = "سرویس ویزه نظافت" });
            builder.HasData(new Service { Id = 3, SubCategoryId = 1 , Title = "سرویس لوکس نظافت" });
            builder.HasData(new Service { Id = 4, SubCategoryId = 1 , Title = "نظافت راه پله" });
            builder.HasData(new Service { Id = 5, SubCategoryId = 1 , Title = "سرویس نظافت فوری" });
            builder.HasData(new Service { Id = 6, SubCategoryId = 1 , Title = "پذیرایی" });
            builder.HasData(new Service { Id = 7, SubCategoryId = 2 , Title = "شست و شو در محل" });
            builder.HasData(new Service { Id = 8, SubCategoryId = 2 , Title = "قالیشویی" });
            builder.HasData(new Service { Id = 9, SubCategoryId = 2 , Title = "خشکشویی" });
            builder.HasData(new Service { Id = 10, SubCategoryId = 2, Title = "پرده شویی" });
            builder.HasData(new Service { Id = 11, SubCategoryId = 3 , Title = "تعمیر و سرویس کولر آبی" });
            builder.HasData(new Service { Id = 12, SubCategoryId = 3 , Title = "تعمیر کولر گازی و داکت اسپیلت" });
            builder.HasData(new Service { Id = 13, SubCategoryId = 3 , Title = "تعمیر و سرویس پکیج" });
            builder.HasData(new Service { Id = 14, SubCategoryId = 3 , Title = "تعمیر و سرویس آبگرمکن" });
            #endregion
        }
    }
}
