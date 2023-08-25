using System.ComponentModel.DataAnnotations;

namespace KuleliGallery.Shop.UI.Models.RequestModels
{
    public class UpdateCategoryVM
    {
        public int Id { get; set; }

        [Display(Name="KATEGORİ ADI")]
        public string CategoryName { get; set; }
    }
}
