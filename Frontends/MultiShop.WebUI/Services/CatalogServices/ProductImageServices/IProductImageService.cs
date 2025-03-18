using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImagesServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
    }
}
