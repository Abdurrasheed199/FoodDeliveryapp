namespace FoodDeliveryApi.DTO_s.UserCartDTO
{
    public class ProductCartDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }
    }
}
