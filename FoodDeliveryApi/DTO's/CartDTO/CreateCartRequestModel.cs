namespace FoodDeliveryApi.DTO_s.CartDTO
{
    public class CreateCartRequestModel
    {
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

    public class CartItem
    { 
        public string ProductId { get; set;}
        public int Quantity { get; set;}
    }
}
