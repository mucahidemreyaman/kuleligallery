using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.RequestModels.ProductImages
{
    public class CreateProductImageVM
    {
        
        public int? ProductId { get; set; }
        [Display(Name ="SIRA NO")]
        public int? Order { get; set; } = 0;

        [Display(Name ="VARSAYILAN RESİM")]
        public bool? IsThumbnail { get; set; }

        [Display(Name ="RESİM DOSYASI")]
        public IFormFile ImageFile { get; set; }
        public string UploadedImage { get; set; }
    }
}


