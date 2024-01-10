namespace FoodDeliveryApi.DTO_s.CustomerDTO
{
    public class CustomersResponseModel : BaseResponse<List<CustomerDto>>
    {
        public List<CustomerDto> Customers { get; set;} = new List<CustomerDto>();
    }
}
