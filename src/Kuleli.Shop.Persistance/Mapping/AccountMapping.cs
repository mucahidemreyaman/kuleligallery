using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class AccountMapping : BaseEntityMapping<Account>
    {
       

        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Account> builder)
        {

            builder.Property(x => x.CustomerId)
               .HasColumnName("CUSTOMER_ID")
               .HasColumnOrder(2);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(10)")
                .HasColumnName("USER_NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("PASSWORD")
                .HasColumnOrder(4);

            builder.Property(x => x.LastLoginDate)
                .HasColumnName("LAST_LOGIN_DATE")
                .HasColumnOrder(5);

            builder.Property(x => x.LastUserIp)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("LAST_USER_IP")
                .HasColumnOrder(6);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Account);
        }
    }

}
