namespace FoodDeliveryApi.DTO_s
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; } = false;
        public T Data { get; set; }
        public List<string> ValidationResults { get; set; } = new List<string>();
    }
}
