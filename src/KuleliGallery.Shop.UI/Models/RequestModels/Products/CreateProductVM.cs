using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.RequestModels.Products
{
    public class CreateProductVM
    {
        [Display(Name = "KATEGORİ")]
        public int? CategoryId { get; set; }

        [Display(Name="ÜRÜN ADI")]
        public string Name { get; set; }

        [Display(Name = "AÇIKLAMA")]
        public string Detail { get; set; }

        [Display(Name = "STOK ADEDİ")]
        public int? UnitInStock { get; set; }

        [Display(Name = "BİRİM FİYATI")]
        public decimal? UnitPrice { get; set; }
    }
}


