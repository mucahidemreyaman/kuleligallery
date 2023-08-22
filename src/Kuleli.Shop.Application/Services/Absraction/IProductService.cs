using Kuleli.Shop.Application.Model.Dtos.Products;
using Kuleli.Shop.Application.Model.RequestModels.Products;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction
{
    public interface IProductService
    {
        #region Select

        Task<Result<List<ProductDto>>> GetAllProducts();
        Task<Result<List<ProductWithCategoryDto>>> GetAllProductsWithCategory();
        Task<Result<ProductDto>> GetProductById(GetProductByIdVM getProductByIdVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<int>> UpdateProduct(UpdateProductVM updateProductVM);
        Task<Result<int>> DeleteProduct(DeleteProductVM deleteProductVM);

        #endregion
    }
}
