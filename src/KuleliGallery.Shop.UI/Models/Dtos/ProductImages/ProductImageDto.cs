using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.Dtos.ProductImages
{
    public class ProductImageDto
    {
        
        public int Id { get; set; }
        [Display(Name ="ÜRÜN NO")]
        public int ProductId { get; set; }

        [Display(Name ="RESİM")]
        public string Path { get; set; }
        [Display(Name ="SIRA NO")]
        public int Order { get; set; }

        [Display(Name ="DURUMU")]
        public bool? IsThumbnail { get; set; }
    }
}
