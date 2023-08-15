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

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductComments)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("COMMENT_PRODUCT_PRODUCT_ID")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.ProductComments)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("COMMENT_CUSTOMER_CUSTOMER_ID");

            builder.ToTable("PRODUCT_COMMENTS");




        }
    }
}
