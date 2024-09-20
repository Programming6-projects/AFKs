using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Pepsi.Core.Interfaces.Mappers;
using Moq;

namespace Pepsi.Tests.Core.Mappers
{
    public class OrderItemMapperTests
    {
        private readonly OrderItemMapper _mapper;
        private readonly Mock<IMapper<Product, ProductDto>> _productMapperMock;

        public OrderItemMapperTests()
        {
            _productMapperMock = new Mock<IMapper<Product, ProductDto>>();
            _mapper = new OrderItemMapper(_productMapperMock.Object);
        }

        [Fact]
        public void MapToDtoShouldMapOrderItemToOrderItemDto()
        {
            var product = new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };
            var orderItem = new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Product = product, Quantity = 10, UnitPrice = 1000.5m };
            var productDto = new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            _productMapperMock.Setup(m => m.MapToDto(product)).Returns(productDto);

            var orderItemDto = _mapper.MapToDto(orderItem);

            Assert.Equal(orderItem.Id, orderItemDto.Id);
            Assert.Equal(orderItem.OrderId, orderItemDto.OrderId);
            Assert.Equal(orderItem.ProductId, orderItemDto.ProductId);
            Assert.Equal(orderItem.Quantity, orderItemDto.Quantity);
            Assert.Equal(orderItem.UnitPrice, orderItemDto.UnitPrice);
            Assert.Equal(productDto, orderItemDto.Product);
        }

        [Fact]
        public void MapToEntityShouldMapOrderItemDtoToOrderItem()
        {
            var orderItemDto = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };

            var orderItem = _mapper.MapToEntity(orderItemDto);

            Assert.Equal(orderItemDto.Id, orderItem.Id);
            Assert.Equal(orderItemDto.OrderId, orderItem.OrderId);
            Assert.Equal(orderItemDto.ProductId, orderItem.ProductId);
            Assert.Equal(orderItemDto.Quantity, orderItem.Quantity);
            Assert.Equal(orderItemDto.UnitPrice, orderItem.UnitPrice);
        }

        [Fact]
        public void MapToDtoListShouldMapOrderItemListToOrderItemDtoList()
        {
            var product = new Product { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };
            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Product = product, Quantity = 10, UnitPrice = 1000.5m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 5, UnitPrice = 500.5m }
            };
            var productDto = new ProductDto { Id = 1, Name = "Pepsi", Price = 99.99m, Weight = 1.5m };

            _productMapperMock.Setup(m => m.MapToDto(product)).Returns(productDto);

            var orderItemDtos = _mapper.MapToDtoList(orderItems);

            var itemDtos = orderItemDtos as OrderItemDto[] ?? orderItemDtos.ToArray();
            Assert.Equal(orderItems.Count, itemDtos.Length);
            Assert.Equal(orderItems[0].Id, itemDtos.ElementAt(0).Id);
            Assert.Equal(orderItems[1].Id, itemDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapOrderItemDtoListToOrderItemList()
        {
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m },
                new OrderItemDto { Id = 2, OrderId = 1, ProductId = 2, Quantity = 5, UnitPrice = 500.5m }
            };

            var orderItems = _mapper.MapToEntityList(orderItemDtos);

            var enumerable = orderItems as OrderItem[] ?? orderItems.ToArray();
            Assert.Equal(orderItemDtos.Count, enumerable.Length);
            Assert.Equal(orderItemDtos[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(orderItemDtos[1].Id, enumerable.ElementAt(1).Id);
        }
    }
}
