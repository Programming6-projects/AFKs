using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Pepsi.Core.Interfaces.Mappers;
using Moq;

namespace Pepsi.Tests.Core.Mappers
{
    public class OrderMapperTests
    {
        private readonly OrderMapper _mapper;
        private readonly Mock<IMapper<OrderItem, OrderItemDto>> _orderItemMapperMock;
        private readonly Mock<IMapper<Client, ClientDto>> _clientMapperMock;
        private readonly Mock<IMapper<Vehicle, VehicleDto>> _vehicleMapperMock;

        public OrderMapperTests()
        {
            _orderItemMapperMock = new Mock<IMapper<OrderItem, OrderItemDto>>();
            _clientMapperMock = new Mock<IMapper<Client, ClientDto>>();
            _vehicleMapperMock = new Mock<IMapper<Vehicle, VehicleDto>>();
            _mapper = new OrderMapper(_orderItemMapperMock.Object, _clientMapperMock.Object, _vehicleMapperMock.Object);
        }

        [Fact]
        public void MapToDtoShouldMapOrderToOrderDto()
        {
            var client = new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var order = new Order { Id = 1, ClientId = 1, Client = client, VehicleId = 1, Vehicle = vehicle, Items = orderItems, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending };

            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };

            _clientMapperMock.Setup(m => m.MapToDto(client)).Returns(clientDto);
            _vehicleMapperMock.Setup(m => m.MapToDto(vehicle)).Returns(vehicleDto);
            _orderItemMapperMock.Setup(m => m.MapToDtoList(orderItems)).Returns(orderItemDtos);

            var orderDto = _mapper.MapToDto(order);

            Assert.Equal(order.Id, orderDto.Id);
            Assert.Equal(order.ClientId, orderDto.ClientId);
            Assert.Equal(clientDto, orderDto.Client);
            Assert.Equal(order.VehicleId, orderDto.VehicleId);
            Assert.Equal(vehicleDto, orderDto.Vehicle);
            Assert.Equal(orderItemDtos, orderDto.Items);
            Assert.Equal(order.TotalVolume, orderDto.TotalVolume);
            Assert.Equal(order.OrderDate, orderDto.OrderDate);
            Assert.Equal(order.DeliveryDate, orderDto.DeliveryDate);
            Assert.Equal(order.Status, orderDto.Status);
        }

        [Fact]
        public void MapToEntityShouldMapOrderDtoToOrder()
        {
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var orderDto = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, Items = orderItemDtos, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending };

            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };

            _orderItemMapperMock.Setup(m => m.MapToEntityList(orderItemDtos)).Returns(orderItems);

            var order = _mapper.MapToEntity(orderDto);

            Assert.Equal(orderDto.Id, order.Id);
            Assert.Equal(orderDto.ClientId, order.ClientId);
            Assert.Equal(orderDto.VehicleId, order.VehicleId);
            Assert.Equal(orderItems, order.Items);
            Assert.Equal(orderDto.TotalVolume, order.TotalVolume);
            Assert.Equal(orderDto.OrderDate, order.OrderDate);
            Assert.Equal(orderDto.DeliveryDate, order.DeliveryDate);
            Assert.Equal(orderDto.Status, order.Status);
        }

        [Fact]
        public void MapToDtoListShouldMapOrderListToOrderDtoList()
        {
            var client = new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var orders = new List<Order>
            {
                new Order { Id = 1, ClientId = 1, Client = client, VehicleId = 1, Vehicle = vehicle, Items = orderItems, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending }
            };

            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var orderDtos = new List<OrderDto>
            {
                new OrderDto { Id = 1, ClientId = 1, Client = clientDto, VehicleId = 1, Vehicle = vehicleDto, Items = orderItemDtos, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending }
            };

            _clientMapperMock.Setup(m => m.MapToDto(client)).Returns(clientDto);
            _vehicleMapperMock.Setup(m => m.MapToDto(vehicle)).Returns(vehicleDto);
            _orderItemMapperMock.Setup(m => m.MapToDtoList(orderItems)).Returns(orderItemDtos);

            var result = _mapper.MapToDtoList(orders);

            var enumerable = result as OrderDto[] ?? result.ToArray();
            Assert.Equal(orderDtos.Count, enumerable.Length);
            Assert.Equal(orderDtos[0].Id, enumerable.ElementAt(0).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapOrderDtoListToOrderList()
        {
            var orderItemDtos = new List<OrderItemDto>
            {
                new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var orderDtos = new List<OrderDto>
            {
                new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, Items = orderItemDtos, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending }
            };

            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m }
            };
            var orders = new List<Order>
            {
                new Order { Id = 1, ClientId = 1, VehicleId = 1, Items = orderItems, TotalVolume = 1000.5m, OrderDate = new DateTime(2023, 10, 1), DeliveryDate = new DateTime(2023, 10, 2), Status = OrderStatus.Pending }
            };

            _orderItemMapperMock.Setup(m => m.MapToEntityList(orderItemDtos)).Returns(orderItems);

            var result = _mapper.MapToEntityList(orderDtos);

            var enumerable = result as Order[] ?? result.ToArray();
            Assert.Equal(orders.Count, enumerable.Length);
            Assert.Equal(orders[0].Id, enumerable.ElementAt(0).Id);
        }
    }
}
