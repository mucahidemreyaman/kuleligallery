using KuleliGallery.Shop.UI.Models.Dtos.ProductImages;

namespace KuleliGallery.Shop.UI.Models.Dtos.Products
{
    public class ProductWithImagesDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public CategoryDto Category { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
    }
}
