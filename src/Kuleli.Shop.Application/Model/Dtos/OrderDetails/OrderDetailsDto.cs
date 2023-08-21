using Kuleli.Shop.Application.Model.Dtos.CategoryDtos;
using Kuleli.Shop.Application.Model.Dtos.Products;

namespace Kuleli.Shop.Application.Model.Dtos.OrderDetails
{
    public class OrderDetailsDto
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
