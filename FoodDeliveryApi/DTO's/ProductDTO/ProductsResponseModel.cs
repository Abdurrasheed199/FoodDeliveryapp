namespace FoodDeliveryApi.DTO_s.MenuItemDTO
{
    public class ProductsResponseModel : BaseResponse<List<ProductDto>>
    {
        public List<ProductDto> Products { get; set;}
    }
}
