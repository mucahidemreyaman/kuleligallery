using Kuleli.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kuleli.Shop.Persistance.Mapping
{
    public class ProductCommentMapping : AuditableEntityMapping<ProductComment>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<ProductComment> builder)
        {
            builder.Property(x => x.ProductId)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)")
                   .HasColumnName("PRODUCT_ID")
                   .HasColumnOrder(2);

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(3);

            builder.Property(x => x.Detail)
                .IsRequired()
                .HasColumnType("nvarchar(max)")
                .HasColumnName("DETAIL")
                .HasColumnOrder(4);

            builder.Property(x => x.LikeCount)
               .HasColumnName("LIKE_COUNT")
               .HasColumnOrder(5);

            builder.Property(x => x.DisLikeCount)
              .HasColumnName("DISLIKE_COUNT")
              .HasColumnOrder(6);

            builder.Property(x => x.LikeCount)
            .HasColumnName("IS_APPROVED")
            .HasDefaultValueSql("0")
            .HasColumnOrder(7);


        }
    }
}
