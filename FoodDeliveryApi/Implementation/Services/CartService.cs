using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.CartDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;

namespace FoodDeliveryApi.Implementation.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private ICartRepository _cartRepository;

        public CartService(IProductRepository productRepository, IUserRepository userRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }

        public async Task<BaseResponse<string>> CreateCart(CreateCartRequestModel model, CancellationToken cancellationToken)
        {

            var cart = new Cart
            {
                UserId = model.UserId,
                IsActive = true
            };

             await _cartRepository.CreateAsync(cart);
            decimal totalAmount = 0;
            foreach(var item in model.CartItems)
            {
                var cartItem = new ProductCart
                {
                    CartId = cart.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                cart.ProductCarts.Add(cartItem);
                var product = await _productRepository.GetAsync<Product>(a => a.Id == item.ProductId);
                if(product.Quantity >= item.Quantity)
                {
                    product.Quantity -= item.Quantity;
                }
                totalAmount += (item.Quantity * product.Price);
            }

            cart.TotalAmount = totalAmount;
            var c =  _cartRepository.SaveChangesAsync(cancellationToken);
            return new BaseResponse<string>
            {
                Data = cart.Id,
            };
  
        }

        public async Task<BaseResponse<CartDto>> DeleteCartById(string cartId,string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(cartId)) throw new ArgumentNullException(null);
            var cart = await _cartRepository.GetCartById(cartId, cancellationToken);
            if (cart == null) 
            return new BaseResponse<CartDto>
            {
                Message = "Does not exist",
                Status = false
            };
            await _cartRepository.RemoveAsync<Cart>(cart);
            return new BaseResponse<CartDto>
            {

                Message = "Successfully removed",
                Status = true

            };
        }

        public async Task<BaseResponse<CartDto>> GetCartById(string cartId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var cart = await _cartRepository.GetCart(c => c.Id == cartId, cancellationToken);
            if (cart == null)
            {
                return new BaseResponse<CartDto>
                {
                    Message = "Cart not found",
                    Status = false
                };
            }
           
            return new BaseResponse<CartDto>
            {
                Data = new CartDto
                {
                  Id = cart.Id,
                  TotalAmount = cart.TotalAmount,
                  
                  
                  
                },

                Message = "Successfull",
                Status = true
            };
        }
    }
}
