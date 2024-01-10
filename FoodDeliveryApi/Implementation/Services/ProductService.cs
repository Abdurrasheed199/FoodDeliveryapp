using FoodDeliveryApi.DTO_s.MenuItemDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;

namespace FoodDeliveryApi.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel model, CancellationToken cancellationToken)
        {
            CreateProductResponseModel createProductResponseModel = new();
            var menuItemAvailable = await _productRepository.ExistsAsync<Product>(p => p.ProductName  == model.ProductName);
            if (menuItemAvailable) 
            {
                createProductResponseModel.Message = " Item On the Menu Already Available";
                createProductResponseModel.Status = false;

                return createProductResponseModel;
            }

            var product = new Product(model.ProductName, model.ProductDescription, model.Price, model.Quantity, model.Image);
            await _productRepository.SaveChangesAsync(cancellationToken);
            createProductResponseModel.Status = true;
            createProductResponseModel.Message = " Item is Now Availble";
            return createProductResponseModel;
        }
    }
}
