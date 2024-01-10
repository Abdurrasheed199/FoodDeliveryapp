namespace FoodDeliveryApi.DTO_s.DeliveryDTO
{
    public class DeliveryResponseModel : BaseResponse<DeliveryDto>
    {
        public DeliveryDto Delivery { get; set; }   
    }
}
