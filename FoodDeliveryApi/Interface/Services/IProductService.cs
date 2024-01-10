using FoodDeliveryApi.DTO_s.DeliveryDTO;
using FoodDeliveryApi.DTO_s.MenuItemDTO;

namespace FoodDeliveryApi.Interface.Services
{
    public interface IProductService
    {
        Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel model, CancellationToken cancellationToken);
    }
}
