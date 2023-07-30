using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class ProductImage : AuditableEntity
    {
        public int ProductId { get; set; }
        public string FileName { get; set; }

        public int Order { get; set; }

        public bool IsThumbnail { get; set; }

        // Navigation Property :)

        public Product Products { get; set; }

    }
}
