using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.RequestModels
{
    public class CreateCategoryVM
    {
        [Display(Name = "KATEGORİ ADI")]
        public string CategoryName { get; set; }
    }
}
