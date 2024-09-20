using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;

namespace Pepsi.Tests.Core.Mappers
{
    public class ProductStockMapperTests
    {
        private readonly ProductStockMapper _mapper;

        public ProductStockMapperTests()
        {
            _mapper = new ProductStockMapper();
        }

        [Fact]
        public void MapToDtoShouldMapProductStockToProductStockDto()
        {
            var productStock = new ProductStock { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 };

            var productStockDto = _mapper.MapToDto(productStock);

            Assert.Equal(productStock.Id, productStockDto.Id);
            Assert.Equal(productStock.QuantityOnHand, productStockDto.QuantityOnHand);
            Assert.Equal(productStock.QuantitySold, productStockDto.QuantitySold);
            Assert.Equal(productStock.QuantityReserved, productStockDto.QuantityReserved);
            Assert.Equal(productStock.ProductId, productStockDto.ProductId);
        }

        [Fact]
        public void MapToEntityShouldMapProductStockDtoToProductStock()
        {
            var productStockDto = new ProductStockDto { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 };

            var productStock = _mapper.MapToEntity(productStockDto);

            Assert.Equal(productStockDto.Id, productStock.Id);
            Assert.Equal(productStockDto.QuantityOnHand, productStock.QuantityOnHand);
            Assert.Equal(productStockDto.QuantitySold, productStock.QuantitySold);
            Assert.Equal(productStockDto.QuantityReserved, productStock.QuantityReserved);
            Assert.Equal(productStockDto.ProductId, productStock.ProductId);
        }

        [Fact]
        public void MapToDtoListShouldMapProductStockListToProductStockDtoList()
        {
            var productStocks = new List<ProductStock>
            {
                new ProductStock { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 },
                new ProductStock { Id = 2, QuantityOnHand = 200, QuantitySold = 100, QuantityReserved = 40, ProductId = 2 }
            };

            var productStockDtos = _mapper.MapToDtoList(productStocks);

            var stockDtos = productStockDtos as ProductStockDto[] ?? productStockDtos.ToArray();
            Assert.Equal(productStocks.Count, stockDtos.Length);
            Assert.Equal(productStocks[0].Id, stockDtos.ElementAt(0).Id);
            Assert.Equal(productStocks[1].Id, stockDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapProductStockDtoListToProductStockList()
        {
            var productStockDtos = new List<ProductStockDto>
            {
                new ProductStockDto { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 },
                new ProductStockDto { Id = 2, QuantityOnHand = 200, QuantitySold = 100, QuantityReserved = 40, ProductId = 2 }
            };

            var productStocks = _mapper.MapToEntityList(productStockDtos);

            var enumerable = productStocks as ProductStock[] ?? productStocks.ToArray();
            Assert.Equal(productStockDtos.Count, enumerable.Length);
            Assert.Equal(productStockDtos[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(productStockDtos[1].Id, enumerable.ElementAt(1).Id);
        }
    }
}
