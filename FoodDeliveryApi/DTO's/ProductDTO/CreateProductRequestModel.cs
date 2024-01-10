namespace FoodDeliveryApi.DTO_s.MenuItemDTO
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        //public bool IsAvailable { get; set; }
        public string Image { get; set; }
        public List<string> CartIds { get; set; }
    }
}
