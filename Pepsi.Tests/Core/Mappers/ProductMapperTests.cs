using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;

namespace Pepsi.Tests.Core.Mappers
{
    public class ProductMapperTests
    {
        private readonly ProductMapper _mapper;

        public ProductMapperTests()
        {
            _mapper = new ProductMapper();
        }

        [Fact]
        public void MapToDtoShouldMapProductToProductDto()
        {
            var product = new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            var productDto = _mapper.MapToDto(product);

            Assert.Equal(product.Id, productDto.Id);
            Assert.Equal(product.Name, productDto.Name);
            Assert.Equal(product.Price, productDto.Price);
            Assert.Equal(product.Weight, productDto.Weight);
        }

        [Fact]
        public void MapToEntityShouldMapProductDtoToProduct()
        {
            var productDto = new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            var product = _mapper.MapToEntity(productDto);

            Assert.Equal(productDto.Id, product.Id);
            Assert.Equal(productDto.Name, product.Name);
            Assert.Equal(productDto.Price, product.Price);
            Assert.Equal(productDto.Weight, product.Weight);
        }

        [Fact]
        public void MapToDtoListShouldMapProductListToProductDtoList()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m },
                new Product { Id = 2, Name = "Coke", Price = 89.99m, Weight = 1.0m }
            };

            var productDtos = _mapper.MapToDtoList(products);

            var enumerable = productDtos as ProductDto[] ?? productDtos.ToArray();
            Assert.Equal(products.Count, enumerable.Length);
            Assert.Equal(products[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(products[1].Id, enumerable.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapProductDtoListToProductList()
        {
            var productDtos = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m },
                new ProductDto { Id = 2, Name = "Coke", Price = 89.99m, Weight = 1.0m }
            };

            var products = _mapper.MapToEntityList(productDtos);

            var enumerable = products as Product[] ?? products.ToArray();
            Assert.Equal(productDtos.Count, enumerable.Length);
            Assert.Equal(productDtos[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(productDtos[1].Id, enumerable.ElementAt(1).Id);
        }
    }
}
