using App.Domain.Core.Adress.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class CityConfigorarion : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(25);
        }
    }
}
