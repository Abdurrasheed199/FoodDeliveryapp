namespace FoodDeliveryApi.DTO_s.OrderDTO
{
    public class CreateOrderResponseModel : BaseResponse<string>
    {
        public string OrderId { get; set; }
    }
}
