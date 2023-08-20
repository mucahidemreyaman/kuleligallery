using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class CityMapping : BaseEntityMapping<City>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("CITY_NAME")
                .HasColumnType("nvarchar(20)")
                .HasColumnOrder(2);

            builder.ToTable("CITIES");

        }
    }
}
