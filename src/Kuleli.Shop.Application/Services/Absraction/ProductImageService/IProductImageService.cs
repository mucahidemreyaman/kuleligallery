using Kuleli.Shop.Application.Model.Dtos.ProductImages;
using Kuleli.Shop.Application.Model.RequestModels.ProductImages;
using Kuleli.Shop.Application.Wrapper;

namespace Kuleli.Shop.Application.Services.Absraction.ProductImageService
{
    public interface IProductImageService
    {
        #region Select

        Task<Result<List<ProductImageDto>>> GetAllImagesByProduct(GetAllProductImageByProductVM getByProductVM);
        Task<Result<List<ProductImageWithProductDto>>> GetAllProductImagesWithProduct(GetAllProductImageByProductVM getByProductVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateProductImage(CreateProductImageVM createProductImageVM);
        Task<Result<int>> DeleteProductImage(DeleteProductImageVM deleteProductImageVM);

        #endregion
    }
}
