namespace FoodDeliveryApi.DTO_s.CustomerDTO
{
    public class CustomerResponseModel : BaseResponse<CustomerDto>
    {
        public CustomerDto Customer { get; set; }
    }
}
