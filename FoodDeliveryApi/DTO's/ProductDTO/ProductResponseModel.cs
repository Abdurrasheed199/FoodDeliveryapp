namespace FoodDeliveryApi.DTO_s.MenuItemDTO
{
    public class ProductResponseModel : BaseResponse<ProductDto>
    {
        public ProductDto Product { get; set; }
    }
}
