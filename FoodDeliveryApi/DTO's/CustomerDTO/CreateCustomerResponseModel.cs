namespace FoodDeliveryApi.DTO_s.CustomerDTO
{
    public class CreateCustomerResponseModel : BaseResponse<Guid>
    {
        public Guid CustomerId { get; set; }
    }
}
