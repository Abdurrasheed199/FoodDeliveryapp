namespace FoodDeliveryApi.DTO_s.DeliveryDTO
{
    public class DeliveriesResponseModel : BaseResponse<List<DeliveryDto>>
    {
        public List<DeliveryDto> Deliveries { get; set; }
    }
}
