using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Xunit;
using System.Collections.Generic;
using System.Linq;

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
        public void MapToDto_ShouldMapProductStockToProductStockDto()
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
        public void MapToEntity_ShouldMapProductStockDtoToProductStock()
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
        public void MapToDtoList_ShouldMapProductStockListToProductStockDtoList()
        {
            var productStocks = new List<ProductStock>
            {
                new ProductStock { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 },
                new ProductStock { Id = 2, QuantityOnHand = 200, QuantitySold = 100, QuantityReserved = 40, ProductId = 2 }
            };

            var productStockDtos = _mapper.MapToDtoList(productStocks);

            Assert.Equal(productStocks.Count(), productStockDtos.Count());
            Assert.Equal(productStocks[0].Id, productStockDtos.ElementAt(0).Id);
            Assert.Equal(productStocks[1].Id, productStockDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityList_ShouldMapProductStockDtoListToProductStockList()
        {
            var productStockDtos = new List<ProductStockDto>
            {
                new ProductStockDto { Id = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20, ProductId = 1 },
                new ProductStockDto { Id = 2, QuantityOnHand = 200, QuantitySold = 100, QuantityReserved = 40, ProductId = 2 }
            };

            var productStocks = _mapper.MapToEntityList(productStockDtos);

            Assert.Equal(productStockDtos.Count(), productStocks.Count());
            Assert.Equal(productStockDtos[0].Id, productStocks.ElementAt(0).Id);
            Assert.Equal(productStockDtos[1].Id, productStocks.ElementAt(1).Id);
        }
    }
}
