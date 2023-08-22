using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class CustomerMapping : AuditableEntityMapping<Customer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Customer> builder)
        {
            

            builder.Property(x => x.CityId)
                .HasColumnName("CITY_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.IdentityNumber)
              .HasColumnName("IDENTITY_NUMBER")
              .HasColumnType("nchar(11)")
              .IsRequired()
              .HasColumnOrder(4);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasColumnType("nvarchar(30)")
              .HasColumnName("NAME")
              .HasColumnOrder(5);

            builder.Property(x => x.Surname)
              .IsRequired()
              .HasColumnType("nvarchar(30)")
              .HasColumnName("SURNAME")
              .HasColumnOrder(6);

            builder.Property(x => x.Email)
              .IsRequired()
              .HasColumnName("EMAIL")
              .HasColumnOrder(7)
              .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Phone)
              .HasColumnName("PHONE")
              .HasColumnType("nchar(13)")
              .HasColumnOrder(8);

            builder.Property(x => x.Birthday)
                .HasColumnName("BIRTHDAY")
                .IsRequired()
                .HasColumnOrder(9);

            builder.Property(x => x.Gender)
                .HasColumnName("GENDER")
                .IsRequired()
                .HasColumnOrder(10);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.CityId)
                .IsRequired(false)
                .HasConstraintName("CUSTOMER_CITY_CITY_ID");

            builder.ToTable("CUSTOMERS");

        }
    }
}
