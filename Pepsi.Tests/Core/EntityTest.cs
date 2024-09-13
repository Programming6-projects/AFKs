using Pepsi.Core.Entity;

namespace Pepsi.Tests.Core;

public class EntityTest
{

    [Fact]
    public void VehicleIdShouldBeSetCorrectly()
    {
        var vehicle = new Vehicle(1, "Truck", 100000);
        Assert.Equal(1, vehicle.Id);
    }

    [Fact]
    public void VehicleVehicleTypeShouldBeSetCorrectly()
    {
        var vehicle = new Vehicle(1, "Truck", 100000);
        Assert.Equal("Truck", vehicle.VehicleType);
    }

    [Fact]
    public void VehicleCapacityShouldBeSetCorrectly()
    {
        var vehicle = new Vehicle(1, "Truck", 1000.5m);
        Assert.Equal(1000.5m, vehicle.Capacity);
    }

    [Fact]
    public void ClientIdShouldBeSetCorrectly()
    {
        var client = new Client(1, "Santiago", "Av Sin Nombre", "Cochabamba");
        Assert.Equal(1, client.Id);
    }

    [Fact]
    public void ClientNameShouldBeSetCorrectly()
    {
        var client = new Client(1, "Santiago", "Av Sin Nombre", "Cochabamba");
        Assert.Equal("Santiago", client.Name);
    }

    [Fact]
    public void ClientAddressShouldBeSetCorrectly()
    {
        var client = new Client(1, "Santiago", "123", "Cochabamba");
        Assert.Equal("123", client.Address);
    }

    [Fact]
    public void ClientRegionShouldBeSetCorrectly()
    {
        var client = new Client(1, "Santiago", "123", "Cochabamba");
        Assert.Equal("Cochabamba", client.Region);
    }

    [Fact]
    public void OrderIdShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal(1, order.Id);
    }

    [Fact]
    public void OrderClientIdShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal(1, order.ClientId);
    }
    [Fact]
    public void OrderVehicleIdShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal(1, order.VehicleId);
    }

    [Fact]
    public void OrderTotalVolumeShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 100.5m, orderDate, orderDate, "Pending");
        Assert.Equal(100.5m, order.TotalVolume);
    }

    [Fact]
    public void OrderOrderDateShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal(orderDate, order.OrderDate);
    }

    [Fact]
    public void OrderDeliveryDateShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal(orderDate, order.DeliveryDate);
    }

    [Fact]
    public void OrderStatusShouldBeSetCorrectly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order(1, 1, 1, 1000.5m, orderDate, orderDate, "Pending");
        Assert.Equal("Pending", order.Status);
    }

    [Fact]
    public void OrderItemIdShouldBeSetCorrectly()
    {
        var orderItem = new OrderItem(1, 1, 1, 10000, 1000.5m);
        Assert.Equal(1, orderItem.Id);
    }

    [Fact]
    public void OrderItemOrderIdShouldBeSetCorrectly()
    {
        var orderItem = new OrderItem(1, 1, 1, 10000, 1000.5m);
        Assert.Equal(1, orderItem.OrderId);
    }

    [Fact]
    public void OrderItemProductIdShouldBeSetCorrectly()
    {
        var orderItem = new OrderItem(1, 1, 1, 10000, 1000.5m);
        Assert.Equal(1, orderItem.ProductId);
    }

    [Fact]
    public void OrderItemQuantityShouldBeSetCorrectly()
    {
        var orderItem = new OrderItem(1, 1, 1, 10, 1000.5m);
        Assert.Equal(10, orderItem.Quantity);
    }

    [Fact]
    public void OrderItemUnitPriceShouldBeSetCorrectly()
    {
        var orderItem = new OrderItem(1, 1, 1, 1000, 15.75m);
        Assert.Equal(15.75m, orderItem.UnitPrice);
    }

    [Fact]
    public void ProductIdShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 10, 10, 15.75m, 500m);
        Assert.Equal(1, product.Id);
    }

    [Fact]
    public void ProductNameShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 10, 10, 15.75m, 500m);
        Assert.Equal("Pepsi", product.Name);
    }

    [Fact]
    public void ProductQuantityOnHandShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 50, 10, 10, 15.75m, 500m);
        Assert.Equal(50, product.QuantityOnHand);
    }

    [Fact]
    public void ProductQuantitySoldShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 30, 10, 15.75m, 500m);
        Assert.Equal(30, product.QuantitySold);
    }

    [Fact]
    public void ProductQuantityReservedShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 10, 20, 15.75m, 500m);
        Assert.Equal(20, product.QuantityReserved);
    }

    [Fact]
    public void ProductPriceShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 10, 10, 99.99m, 500m);
        Assert.Equal(99.99m, product.Price);
    }

    [Fact]
    public void ProductVolumeShouldBeSetCorrectly()
    {
        var product = new Product(1, "Pepsi", 10, 10, 10, 15.75m, 500m);
        Assert.Equal(500m, product.Volume);
    }
}
