using Microsoft.AspNetCore.Http;

namespace Kuleli.Shop.Application.Model.RequestModels.ProductImages
{
    public class CreateProductImageVM
    {
        public int? ProductId { get; set; }
        public int? Order { get; set; } = 0;
        public bool? IsThumbnail { get; set; }
        public string UploadedImage { get; set; }
    }
}
