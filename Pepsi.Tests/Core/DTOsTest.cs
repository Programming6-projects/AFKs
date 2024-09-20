using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;

namespace Pepsi.Tests.Core;

public class DTOsTest
{
    [Fact]
        public void VehicleIdShouldBeSetCorrectly()
        {
            var vehicle = new VehicleDto { Id = 1, Type = "Truck", Capacity = 100000 };
            Assert.Equal(1, vehicle.Id);
        }

        [Fact]
        public void VehicleVehicleTypeShouldBeSetCorrectly()
        {
            var vehicle = new VehicleDto { Id = 1, Type = "Truck", Capacity = 100000 };
            Assert.Equal("Truck", vehicle.Type);
        }

        [Fact]
        public void VehicleCapacityShouldBeSetCorrectly()
        {
            var vehicle = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            Assert.Equal(1000.5m, vehicle.Capacity);
        }

        [Fact]
        public void ClientIdShouldBeSetCorrectly()
        {
            var client = new ClientDto { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            Assert.Equal(1, client.Id);
        }

        [Fact]
        public void ClientNameShouldBeSetCorrectly()
        {
            var client = new ClientDto { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            Assert.Equal("Santiago", client.Name);
        }

        [Fact]
        public void ClientAddressShouldBeSetCorrectly()
        {
            var client = new ClientDto { Id = 1, Name = "Santiago", Address = "123", Region = "Cochabamba" };
            Assert.Equal("123", client.Address);
        }

        [Fact]
        public void ClientRegionShouldBeSetCorrectly()
        {
            var client = new ClientDto { Id = 1, Name = "Santiago", Address = "123", Region = "Cochabamba" };
            Assert.Equal("Cochabamba", client.Region);
        }

        [Fact]
        public void OrderIdShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(1, order.Id);
        }

        [Fact]
        public void OrderClientIdShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(1, order.ClientId);
        }

        [Fact]
        public void OrderVehicleIdShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(1, order.VehicleId);
        }

        [Fact]
        public void OrderTotalVolumeShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 100.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(100.5m, order.TotalVolume);
        }

        [Fact]
        public void OrderOrderDateShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(orderDate, order.OrderDate);
        }

        [Fact]
        public void OrderDeliveryDateShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(orderDate, order.DeliveryDate);
        }

        [Fact]
        public void OrderStatusShouldBeSetCorrectly()
        {
            var orderDate = new DateTime(2023, 10, 1);
            var order = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1, TotalVolume = 1000.5m, OrderDate = orderDate, DeliveryDate = orderDate, Status = OrderStatus.Pending };
            Assert.Equal(OrderStatus.Pending, order.Status);
        }

        [Fact]
        public void OrderItemIdShouldBeSetCorrectly()
        {
            var orderItem = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10000, UnitPrice = 1000.5m };
            Assert.Equal(1, orderItem.Id);
        }

        [Fact]
        public void OrderItemOrderIdShouldBeSetCorrectly()
        {
            var orderItem = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10000, UnitPrice = 1000.5m };
            Assert.Equal(1, orderItem.OrderId);
        }

        [Fact]
        public void OrderItemProductIdShouldBeSetCorrectly()
        {
            var orderItem = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10000, UnitPrice = 1000.5m };
            Assert.Equal(1, orderItem.ProductId);
        }

        [Fact]
        public void OrderItemQuantityShouldBeSetCorrectly()
        {
            var orderItem = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            Assert.Equal(10, orderItem.Quantity);
        }

        [Fact]
        public void OrderItemUnitPriceShouldBeSetCorrectly()
        {
            var orderItem = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            Assert.Equal(1000.5m, orderItem.UnitPrice);
        }

        [Fact]
        public void ProductNameShouldBeSetCorrectly()
        {
            var product = new ProductDto { Name = "Pepsi", Price = 99.99m, Weight = 1.5m };
            Assert.Equal("Pepsi", product.Name);
        }

        [Fact]
        public void ProductPriceShouldBeSetCorrectly()
        {
            var product = new ProductDto { Name = "Pepsi", Price = 99.99m, Weight = 1.5m };
            Assert.Equal(99.99m, product.Price);
        }

        [Fact]
        public void ProductVolumeShouldBeSetCorrectly()
        {
            var product = new ProductDto { Name = "Pepsi", Price = 10.99m, Weight = 1.5m };
            Assert.Equal(1.5m, product.Weight);
        }
}
