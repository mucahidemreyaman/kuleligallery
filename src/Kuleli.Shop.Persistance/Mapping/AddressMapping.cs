using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.CustomerId)
                  .IsRequired()
                  .HasColumnName("CUSTOMER_ID")
                  .HasColumnType("nvarchar(30)")
                  .HasColumnOrder(1);

            builder.Property(x => x.CityId)
                .HasColumnName("CITY_ID")
                .HasColumnType("nvarchar(30)")
                .HasColumnOrder(2);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("PHONE")
                .HasColumnType("nvarchar(30)")
                .HasColumnOrder(3);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(4);

            builder.Property(x => x.AddressText)
                .IsRequired()
                .HasColumnName("ADDRESS_TEXT")
                .HasColumnType("nvarchar(200)")
                .HasColumnOrder(5);

            builder.Property(x => x.IsDefaultAddress)
                .HasColumnName("IS_DELETED_ADDRESS")
                .HasDefaultValueSql("0");


          


        }
    }
}
