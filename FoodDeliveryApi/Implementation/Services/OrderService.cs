using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.CartDTO;
using FoodDeliveryApi.DTO_s.OrderDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;
using System.Collections.Generic;

namespace FoodDeliveryApi.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartService _cartService;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IUserRepository userRepository, ICartService cartService)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _cartService = cartService;
        }

        public async Task<BaseResponse<OrderDto>> ApproveOrder(string orderId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(orderId)) throw new ArgumentNullException(nameof(orderId));
            var order = await _orderRepository.Get(p => p.Id == orderId, cancellationToken);
            if (order == null) return new BaseResponse<OrderDto>
            {
                Message = "Not Found",
                Status = false
            };
            order.IsApproved = true;
            await _orderRepository.Update(order, cancellationToken);
            return new BaseResponse<OrderDto>
            {
                Data = new OrderDto
                {
                    Id = order.Id,
                    Cart = new CartDto
                    {
                        Id = order.CartId,

                        User = new DTO_s.UserDTO.UserDto
                        {
                            FirstName = order.User.FirstName,
                            LastName = order.User.LastName,
                            Email = order.User.Email,
                        },
                        TotalAmount = order.Cart.TotalAmount,


                    },
                    //Date = order.CreatedOn.ToString(),
                    ReferenceNumber = order.ReferenceNumber

                },
                Message = "Approved Successfully",
                Status = true
            };
        }

        public async Task<BaseResponse<IList<OrderDto>>> GetAll(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _orderRepository.GetAllAsync(or => or.UserId == userId, cancellationToken);
            if (order == null) return new BaseResponse<IList<OrderDto>>
            {
                Message = "Failed",
                Status = false
            };

            return new BaseResponse<IList<OrderDto>>
            {
                Data = order.Select(o => new OrderDto
                {

                    Id = o.Id,
                    Cart = new CartDto
                    {
                        Id = o.Cart.Id,
                        TotalAmount = o.Cart.TotalAmount,
                        User = new DTO_s.UserDTO.UserDto
                        {
                            FirstName = o.User.FirstName,
                            LastName = o.User.LastName,
                            Email = o.User.Email,
                        },


                    },
                    Date = o.CreatedOn,
                    ReferenceNumber = o.ReferenceNumber


                }).ToList(),
                Message = "Successful",
                Status = true
            };
        }

        public async Task<BaseResponse<IList<OrderDto>>> GetAllApprovedOrder(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var approvedOrder = await _orderRepository.GetAllAsync(p => p.IsApproved == true, cancellationToken);
            if (approvedOrder == null) return new BaseResponse<IList<OrderDto>>
            {
                Message = "No Approved Purchase",
                Status = false,
            };

            return new BaseResponse<IList<OrderDto>>
            {
                Data = approvedOrder.Select(or => new OrderDto
                {
                    Id = or.Id,
                    Cart = new CartDto
                    {
                        Id = or.CartId,

                    }
                }).ToList(),
                Message = "Successfull",
                Status = true
            };   
               
                       
        }
                
            
     

        public async Task<BaseResponse<IList<OrderDto>>> GetByDate(string date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var order = await _orderRepository.GetAllAsync(s => s.CreatedOn.ToString().Contains(date), cancellationToken);

            if (order == null)
            {
                return new BaseResponse<IList<OrderDto>>
                {
                    Status = false,
                    Message = "No sales made on this date",

                };
            }

            return new BaseResponse<IList<OrderDto>>
            {
                Data = order.Select(s => new OrderDto
                {
                    Id = s.Id,
                    Cart = new CartDto
                    {
                        Id = s.CartId,
                        TotalAmount = s.Cart.TotalAmount,
                    },

                    User = new DTO_s.UserDTO.UserDto
                    {
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                    },

                    Date = s.CreatedOn,
                    ReferenceNumber = s.ReferenceNumber

                }).ToList(),
                Message = "Successful",
                Status = true

            };
               
        }

        public async Task<BaseResponse<IList<OrderDto>>> GetNonApprovedOrders(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var unapprovedOrders = await _orderRepository.GetAllAsync(or => or.IsApproved == false, cancellationToken);
            if (unapprovedOrders == null) return new BaseResponse<IList<OrderDto>>
            {
                Message = "No Avaiable Pending order",
                Status = false,
            };
            return new BaseResponse<IList<OrderDto>>
            {
                Data = unapprovedOrders.Select(pp => new OrderDto
                {
                    Id = pp.Id,
                    Cart = new CartDto
                    {
                        Id = pp.CartId,
                        TotalAmount = pp.Cart.TotalAmount,
                        User = new DTO_s.UserDTO.UserDto
                        {
                            FirstName = pp.User.FirstName,
                            LastName = pp.User.LastName,
                            Email = pp.User.Email,
                        }
                    },
                    Date = pp.CreatedOn,
                    ReferenceNumber = pp.ReferenceNumber

                }).ToList(),
                Message = "Successfull",
                Status = true
            };
        }

        public async Task<BaseResponse<OrderDto>> Create(string cartId, string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _orderRepository.GetAsync<Order>(or => or.CartId == cartId && or.UserId == userId);
            var cart = await _cartRepository.GetCartById(cartId, cancellationToken);

            if (order != null)
                return new BaseResponse<OrderDto>
                {
                    Message = "Exists",
                    Status = false
                };

            if (cart == null)
                return new BaseResponse<OrderDto>
                {
                    Message = "Cart does not exist",
                    Status = false,
                    //return new BaseResponse<OrderDto>;
                };

            var makeOrder = new Order
            {
                UserId = userId,
                IsDeleted = false,
                ReferenceNumber = $"SL-{Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 5)}",
                Date = DateTime.UtcNow,
                CartId = cart.Id,

            };
            makeOrder.IsApproved = false;
            await _orderRepository.CreateAsync<Order>(makeOrder);
            makeOrder.IsApproved = true;
            await _orderRepository.UpdateAsync<Order>(makeOrder);
            await _orderRepository.SaveChangesAsync();

            return new BaseResponse<OrderDto>
            {
                Data = new OrderDto
                {
                    Id = makeOrder.Id,
                    Cart = new CartDto
                    {
                        Id = makeOrder.CartId,/*
                        ProductCarts = makeOrder.Cart.ProductCarts.Select(pr => new ProductCartDto
                        {
                            ProductName = pr.Product.ProductName,

                        }).ToList(),*/
                        TotalAmount = makeOrder.Cart.TotalAmount,
                    },
                    ReferenceNumber = makeOrder.ReferenceNumber,
                    Date = DateTime.UtcNow,

                },

                Message = "Successful",
                Status = true,
            };

        }
    }
}
       



       


