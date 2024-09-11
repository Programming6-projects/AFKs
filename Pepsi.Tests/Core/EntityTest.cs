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

}
