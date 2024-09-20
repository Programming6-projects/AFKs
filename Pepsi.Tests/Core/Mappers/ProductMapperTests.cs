using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Xunit;
using System.Collections.Generic;
using System.Linq;

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
        public void MapToDto_ShouldMapProductToProductDto()
        {
            var product = new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            var productDto = _mapper.MapToDto(product);

            Assert.Equal(product.Id, productDto.Id);
            Assert.Equal(product.Name, productDto.Name);
            Assert.Equal(product.Price, productDto.Price);
            Assert.Equal(product.Weight, productDto.Weight);
        }

        [Fact]
        public void MapToEntity_ShouldMapProductDtoToProduct()
        {
            var productDto = new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            var product = _mapper.MapToEntity(productDto);

            Assert.Equal(productDto.Id, product.Id);
            Assert.Equal(productDto.Name, product.Name);
            Assert.Equal(productDto.Price, product.Price);
            Assert.Equal(productDto.Weight, product.Weight);
        }

        [Fact]
        public void MapToDtoList_ShouldMapProductListToProductDtoList()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m },
                new Product { Id = 2, Name = "Coke", Price = 89.99m, Weight = 1.0m }
            };

            var productDtos = _mapper.MapToDtoList(products);

            Assert.Equal(products.Count, productDtos.Count());
            Assert.Equal(products[0].Id, productDtos.ElementAt(0).Id);
            Assert.Equal(products[1].Id, productDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityList_ShouldMapProductDtoListToProductList()
        {
            var productDtos = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m },
                new ProductDto { Id = 2, Name = "Coke", Price = 89.99m, Weight = 1.0m }
            };

            var products = _mapper.MapToEntityList(productDtos);

            Assert.Equal(productDtos.Count, products.Count());
            Assert.Equal(productDtos[0].Id, products.ElementAt(0).Id);
            Assert.Equal(productDtos[1].Id, products.ElementAt(1).Id);
        }
    }
}
