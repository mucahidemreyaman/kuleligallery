using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.Dtos.Products
{
    public class ProductWithCategoryDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Display(Name="ÜRÜN ADI")]
        public string Name { get; set; }
        public string Detail { get; set; }

        [Display(Name="STOK ADEDİ")]
        public int UnitInStock { get; set; }

        [Display(Name="BİRİM FİYATI")]
        public decimal UnitPrice { get; set; }

        [Display(Name="KATEGORİSİ")]
        public CategoryDto Category { get; set; }
    }
}
