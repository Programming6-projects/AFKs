using Pepsi.Core.Entity;

namespace Pepsi.Tests.Core;

public class EntityTest
{

    [Fact]
    public void Vehicle_Id_Should_Be_Set_Correctly()
    {
        var vehicle = new Vehicle { id = 1 };
        Assert.Equal(1, vehicle.id);
    }

    [Fact]
    public void Vehicle_VehicleType_Should_Be_Set_Correctly()
    {
        var vehicle = new Vehicle { vehicletype = "Truck" };
        Assert.Equal("Truck", vehicle.vehicletype);
    }

    [Fact]
    public void Vehicle_Capacity_Should_Be_Set_Correctly()
    {
        var vehicle = new Vehicle { capacity = 1000.5m };
        Assert.Equal(1000.5m, vehicle.capacity);
    }

    [Fact]
    public void Client_Id_Should_Be_Set_Correctly()
    {
        var client = new Client { id = 1 };
        Assert.Equal(1, client.id);
    }

    [Fact]
    public void Client_Name_Should_Be_Set_Correctly()
    {
        var client = new Client { name = "John Doe" };
        Assert.Equal("John Doe", client.name);
    }

    [Fact]
    public void Client_Address_Should_Be_Set_Correctly()
    {
        var client = new Client { address = "123" };
        Assert.Equal("123", client.address);
    }

    [Fact]
    public void Client_Region_Should_Be_Set_Correctly()
    {
        var client = new Client { region = "South" };
        Assert.Equal("South", client.region);
    }

    [Fact]
    public void Order_Id_Should_Be_Set_Correctly()
    {
        var order = new Order { id = 1 };
        Assert.Equal(1, order.id);
    }

    [Fact]
    public void Order_ClientId_Should_Be_Set_Correctly()
    {
        var order = new Order { clientId = 1 };
        Assert.Equal(1, order.clientId);
    }
    [Fact]
    public void Order_VehicleId_Should_Be_Set_Correctly()
    {
        var order = new Order { vehicleId = 1 };
        Assert.Equal(1, order.vehicleId);
    }

    [Fact]
    public void Order_TotalVolume_Should_Be_Set_Correctly()
    {
        var order = new Order { totalVolume = 100.5m };
        Assert.Equal(100.5m, order.totalVolume);
    }

    [Fact]
    public void Order_OrderDate_Should_Be_Set_Correctly()
    {
        var orderDate = new DateTime(2023, 10, 1);
        var order = new Order { orderDate = orderDate };
        Assert.Equal(orderDate, order.orderDate);
    }

    [Fact]
    public void Order_DeliveryDate_Should_Be_Set_Correctly()
    {
        var deliveryDate = new DateTime(2023, 10, 5);
        var order = new Order { deliveryDate = deliveryDate };
        Assert.Equal(deliveryDate, order.deliveryDate);
    }

    [Fact]
    public void Order_Status_Should_Be_Set_Correctly()
    {
        var order = new Order { status = "Pending" };
        Assert.Equal("Pending", order.status);
    }

    [Fact]
    public void OrderItem_Id_Should_Be_Set_Correctly()
    {
        var orderItem = new OrderItem { id = 1 };
        Assert.Equal(1, orderItem.id);
    }

    [Fact]
    public void OrderItem_OrderId_Should_Be_Set_Correctly()
    {
        var orderItem = new OrderItem { orderId = 1 };
        Assert.Equal(1, orderItem.orderId);
    }

    [Fact]
    public void OrderItem_ProductId_Should_Be_Set_Correctly()
    {
        var orderItem = new OrderItem { productId = 1 };
        Assert.Equal(1, orderItem.productId);
    }

    [Fact]
    public void OrderItem_Quantity_Should_Be_Set_Correctly()
    {
        var orderItem = new OrderItem { quantity = 10 };
        Assert.Equal(10, orderItem.quantity);
    }

    [Fact]
    public void OrderItem_UnitPrice_Should_Be_Set_Correctly()
    {
        var orderItem = new OrderItem { unitPrice = 15.75m };
        Assert.Equal(15.75m, orderItem.unitPrice);
    }

    [Fact]
    public void Product_Id_Should_Be_Set_Correctly()
    {
        var product = new Product { id = 1 };
        Assert.Equal(1, product.id);
    }

    [Fact]
    public void Product_Name_Should_Be_Set_Correctly()
    {
        var product = new Product { name = "Product A" };
        Assert.Equal("Product A", product.name);
    }

    [Fact]
    public void Product_QuantityOnHand_Should_Be_Set_Correctly()
    {
        var product = new Product { quantityOnHand = 50 };
        Assert.Equal(50, product.quantityOnHand);
    }

    [Fact]
    public void Product_QuantitySold_Should_Be_Set_Correctly()
    {
        var product = new Product { quantitySold = 30 };
        Assert.Equal(30, product.quantitySold);
    }

    [Fact]
    public void Product_QuantityReserved_Should_Be_Set_Correctly()
    {
        var product = new Product { quantityReserved = 20 };
        Assert.Equal(20, product.quantityReserved);
    }

    [Fact]
    public void Product_Price_Should_Be_Set_Correctly()
    {
        var product = new Product { price = 99.99m };
        Assert.Equal(99.99m, product.price);
    }

    [Fact]
    public void Product_Volume_Should_Be_Set_Correctly()
    {
        var product = new Product { volume = 1.5m };
        Assert.Equal(1.5m, product.volume);
    }
}
