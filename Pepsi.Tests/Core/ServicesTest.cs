using Pepsi.Core.Services;
using Moq;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Tests.Core
{
    public class ServicesTest
    {
        //client
        [Fact]
        public async Task ShouldCreateClientSuccessfully()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            var client = new Client { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            mockMapper.Setup(m => m.MapToDto(client)).Returns(clientDto);
            var result = await clientService.AddAsync(clientDto).ConfigureAwait(false);
            Assert.True(result == 0);
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnAllClients()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            var clients = new List<Client> { new Client { Id = 1, Name = "Santiago" } };
            var clientDtos = new List<ClientDto> { new ClientDto { Id = 1, Name = "Santiago" } };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clients);
            mockMapper.Setup(mapper => mapper.MapToDtoList(clients)).Returns(clientDtos);

            var result = await clientService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(clientDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnClientWhenClientExists()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            var client = new Client { Id = 1, Name = "Santiago" };
            var clientDto = new ClientDto { Id = 1, Name = "Santiago" };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(client);
            mockMapper.Setup(mapper => mapper.MapToDto(client)).Returns(clientDto);

            var result = await clientService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(clientDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenClientDoesNotExist()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Client)null!);

            var result = await clientService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetClientsByRegionAsyncShouldReturnClientsWhenClientsExist()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            var clients = new List<Client> { new Client { Id = 1, Name = "Santiago", Region = "Cochabamba" } };
            var clientDtos = new List<ClientDto> { new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba" } };
            mockRepository.Setup(repo => repo.GetClientsByRegionAsync("Cochabamba")).ReturnsAsync(clients);
            mockMapper.Setup(mapper => mapper.MapToDtoList(clients)).Returns(clientDtos);

            var result = await clientService.GetClientsByRegionAsync("Cochabamba").ConfigureAwait(false);

            Assert.Equal(clientDtos, result);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateClient()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);
            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            var client = new Client { Id = 1, Name = "Santiago", Address = "Av Sin Nombre", Region = "Cochabamba" };
            mockMapper.Setup(m => m.MapToEntity(clientDto)).Returns(client);

            await clientService.UpdateAsync(clientDto).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.UpdateAsync(client), Times.Once);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteClient()
        {
            var mockRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper<Client, ClientDto>>();
            var clientService = new ClientService(mockRepository.Object, mockMapper.Object);

            await clientService.DeleteAsync(1).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        //----------------------------------------
        //Order
        [Fact]
        public async Task GetAllAsyncShouldReturnAllOrders()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            var orders = new List<Order> { new Order { Id = 1, ClientId = 1, VehicleId = 1 } };
            var orderDtos = new List<OrderDto> { new OrderDto { Id = 1, ClientId = 1, VehicleId = 1 } };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(orders);
            mockMapper.Setup(mapper => mapper.MapToDtoList(orders)).Returns(orderDtos);

            var result = await orderService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(orderDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnOrderWhenOrderExists()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            var order = new Order { Id = 1, ClientId = 1, VehicleId = 1 };
            var orderDto = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1 };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(order);
            mockMapper.Setup(mapper => mapper.MapToDto(order)).Returns(orderDto);

            var result = await orderService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(orderDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenOrderDoesNotExist()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Order)null!);

            var result = await orderService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsyncShouldAddOrder()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            var orderDto = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1 };
            var order = new Order { Id = 1, ClientId = 1, VehicleId = 1 };
            mockMapper.Setup(m => m.MapToEntity(orderDto)).Returns(order);
            mockRepository.Setup(repo => repo.AddAsync(order)).ReturnsAsync(1);

            var result = await orderService.AddAsync(orderDto).ConfigureAwait(false);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateOrder()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            var orderDto = new OrderDto { Id = 1, ClientId = 1, VehicleId = 1 };
            var order = new Order { Id = 1, ClientId = 1, VehicleId = 1 };
            mockMapper.Setup(m => m.MapToEntity(orderDto)).Returns(order);

            await orderService.UpdateAsync(orderDto).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.UpdateAsync(order), Times.Once);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteOrder()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);

            await orderService.DeleteAsync(1).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetOrdersByClientIdAsyncShouldReturnOrdersWhenOrdersExist()
        {
            var mockRepository = new Mock<IOrderRepository>();
            var mockMapper = new Mock<IMapper<Order, OrderDto>>();
            var mockClientService = new Mock<IClientService>();
            var mockVehicleService = new Mock<IVehicleService>();
            var mockOrderItemService = new Mock<IOrderItemService>();
            var orderService = new OrderService(mockRepository.Object, mockMapper.Object, mockClientService.Object, mockVehicleService.Object, mockOrderItemService.Object);
            var orders = new List<Order> { new Order { Id = 1, ClientId = 1, VehicleId = 1 } };
            var orderDtos = new List<OrderDto> { new OrderDto { Id = 1, ClientId = 1, VehicleId = 1 } };
            mockRepository.Setup(repo => repo.GetOrdersByClientIdAsync(1)).ReturnsAsync(orders);
            mockMapper.Setup(mapper => mapper.MapToDtoList(orders)).Returns(orderDtos);

            var result = await orderService.GetOrdersByClientIdAsync(1).ConfigureAwait(false);

            Assert.Equal(orderDtos, result);
        }

        //----------------------------------------
        //orderItem
        [Fact]
        public async Task GetAllAsyncShouldReturnAllOrderItems()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            var orderItems = new List<OrderItem> { new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m } };
            var orderItemDtos = new List<OrderItemDto> { new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m } };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(orderItems);
            mockMapper.Setup(mapper => mapper.MapToDtoList(orderItems)).Returns(orderItemDtos);

            var result = await orderItemService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(orderItemDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnOrderItemWhenOrderItemExists()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            var orderItem = new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            var orderItemDto = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(orderItem);
            mockMapper.Setup(mapper => mapper.MapToDto(orderItem)).Returns(orderItemDto);

            var result = await orderItemService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(orderItemDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenOrderItemDoesNotExist()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((OrderItem)null!);

            var result = await orderItemService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsyncShouldAddOrderItem()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            var orderItemDto = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            var orderItem = new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            mockMapper.Setup(m => m.MapToEntity(orderItemDto)).Returns(orderItem);
            mockRepository.Setup(repo => repo.AddAsync(orderItem)).ReturnsAsync(1);

            var result = await orderItemService.AddAsync(orderItemDto).ConfigureAwait(false);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateOrderItem()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            var orderItemDto = new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            var orderItem = new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m };
            mockMapper.Setup(m => m.MapToEntity(orderItemDto)).Returns(orderItem);

            await orderItemService.UpdateAsync(orderItemDto).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.UpdateAsync(orderItem), Times.Once);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteOrderItem()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);

            await orderItemService.DeleteAsync(1).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetOrderItemsByOrderIdAsyncShouldReturnOrderItemsWhenOrderItemsExist()
        {
            var mockRepository = new Mock<IOrderItemRepository>();
            var mockMapper = new Mock<IMapper<OrderItem, OrderItemDto>>();
            var orderItemService = new OrderItemService(mockRepository.Object, mockMapper.Object);
            var orderItems = new List<OrderItem> { new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m } };
            var orderItemDtos = new List<OrderItemDto> { new OrderItemDto { Id = 1, OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1000.5m } };
            mockRepository.Setup(repo => repo.GetOrderItemsByOrderIdAsync(1)).ReturnsAsync(orderItems);
            mockMapper.Setup(mapper => mapper.MapToDtoList(orderItems)).Returns(orderItemDtos);

            var result = await orderItemService.GetOrderItemsByOrderIdAsync(1).ConfigureAwait(false);

            Assert.Equal(orderItemDtos, result);
        }

        //----------------------------------------
        //Vehicle
        [Fact]
        public async Task GetAllAsyncShouldReturnAllVehicles()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            var vehicles = new List<Vehicle> { new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m } };
            var vehicleDtos = new List<VehicleDto> { new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m } };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(vehicles);
            mockMapper.Setup(mapper => mapper.MapToDtoList(vehicles)).Returns(vehicleDtos);

            var result = await vehicleService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(vehicleDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnVehicleWhenVehicleExists()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(vehicle);
            mockMapper.Setup(mapper => mapper.MapToDto(vehicle)).Returns(vehicleDto);

            var result = await vehicleService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(vehicleDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenVehicleDoesNotExist()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Vehicle)null!);

            var result = await vehicleService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAvailableVehiclesAsyncShouldReturnAvailableVehicles()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            var vehicles = new List<Vehicle> { new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m } };
            var vehicleDtos = new List<VehicleDto> { new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m } };
            mockRepository.Setup(repo => repo.GetAvailableVehiclesAsync()).ReturnsAsync(vehicles);
            mockMapper.Setup(mapper => mapper.MapToDtoList(vehicles)).Returns(vehicleDtos);

            var result = await vehicleService.GetAvailableVehiclesAsync().ConfigureAwait(false);

            Assert.Equal(vehicleDtos, result);
        }

        [Fact]
        public async Task AddAsyncShouldAddVehicle()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m };
            mockMapper.Setup(m => m.MapToEntity(vehicleDto)).Returns(vehicle);
            mockRepository.Setup(repo => repo.AddAsync(vehicle)).ReturnsAsync(1);

            var result = await vehicleService.AddAsync(vehicleDto).ConfigureAwait(false);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateAsyncShouldUpdateVehicle()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);
            var vehicleDto = new VehicleDto { Id = 1, Type = "Truck", Capacity = 1000.5m };
            var vehicle = new Vehicle { Id = 1, Type = "Truck", Capacity = 1000.5m };
            mockMapper.Setup(m => m.MapToEntity(vehicleDto)).Returns(vehicle);

            await vehicleService.UpdateAsync(vehicleDto).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.UpdateAsync(vehicle), Times.Once);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteVehicle()
        {
            var mockRepository = new Mock<IVehicleRepository>();
            var mockMapper = new Mock<IMapper<Vehicle, VehicleDto>>();
            var vehicleService = new VehicleService(mockRepository.Object, mockMapper.Object);

            await vehicleService.DeleteAsync(1).ConfigureAwait(false);

            mockRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

        //----------------------------------------
        //Product
        [Fact]
        public async Task GetAllAsyncShouldReturnAllProducts()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            var products = new List<Product> { new() { Id = 1, Name = "Pepsi" } };
            var productDtos = new List<ProductDto> { new() { Id = 1, Name = "Pepsi" } };
            mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            mockProductMapper.Setup(mapper => mapper.MapToDtoList(products)).Returns(productDtos);

            var result = await productService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(productDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnProductWhenProductExists()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            var product = new Product { Id = 1, Name = "Pepsi" };
            var productDto = new ProductDto { Id = 1, Name = "Pepsi" };
            mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);
            mockProductMapper.Setup(mapper => mapper.MapToDto(product)).Returns(productDto);

            var result = await productService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(productDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenProductDoesNotExist()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Product)null!);

            var result = await productService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetProductsByNameAsyncShouldReturnProductsWhenProductsExist()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            var products = new List<Product> { new Product { Id = 1, Name = "Pepsi" } };
            var productDtos = new List<ProductDto> { new ProductDto { Id = 1, Name = "Pepsi" } };
            mockProductRepository.Setup(repo => repo.GetProductsByNameAsync("Pepsi")).ReturnsAsync(products);
            mockProductMapper.Setup(mapper => mapper.MapToDtoList(products)).Returns(productDtos);

            var result = await productService.GetProductsByNameAsync("Pepsi").ConfigureAwait(false);

            Assert.Equal(productDtos, result);
        }

        [Fact]
        public async Task GetAllProductsWithStockAsyncShouldReturnProductsWithStock()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            var products = new List<Product> { new Product { Id = 1, Name = "Pepsi" } };
            var productWithStockDto = new ProductWithStockDto { Id = 1, Name = "Pepsi", Stock = new ProductStockDto() };
            mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            mockProductMapper.Setup(mapper => mapper.MapToDto(products[0])).Returns(productWithStockDto);
            mockProductStockService.Setup(service => service.GetStockByProductIdAsync(1)).ReturnsAsync(new ProductStockDto());

            var result = await productService.GetAllProductsWithStockAsync().ConfigureAwait(false);

            var productWithStockDtos = result as ProductWithStockDto[] ?? result.ToArray();
            Assert.Single(productWithStockDtos);
            Assert.Equal(productWithStockDto, productWithStockDtos.First());
        }

        [Fact]
        public async Task GetProductByIdWithStockAsyncShouldReturnProductWithStockWhenProductExists()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            var product = new Product { Id = 1, Name = "Pepsi" };
            var productWithStockDto = new ProductWithStockDto { Id = 1, Name = "Pepsi", Stock = new ProductStockDto() };
            mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);
            mockProductMapper.Setup(mapper => mapper.MapToDto(product)).Returns(productWithStockDto);
            mockProductStockService.Setup(service => service.GetStockByProductIdAsync(1)).ReturnsAsync(new ProductStockDto());

            var result = await productService.GetProductByIdWithStockAsync(1).ConfigureAwait(false);

            Assert.Equal(productWithStockDto, result);
        }

        [Fact]
        public async Task GetProductByIdWithStockAsyncShouldReturnNullWhenProductDoesNotExist()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            var mockProductStockService = new Mock<IProductStockService>();
            var mockProductMapper = new Mock<IMapper<Product, ProductDto>>();
            var productService = new ProductService(mockProductRepository.Object, mockProductStockService.Object, mockProductMapper.Object);
            mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Product)null!);

            var result = await productService.GetProductByIdWithStockAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        //----------------------------------------
        [Fact]
        public async Task GetAllAsyncShouldReturnAllProductStocks()
        {
            var mockRepository = new Mock<IProductStockRepository>();
            var mockMapper = new Mock<IMapper<ProductStock, ProductStockDto>>();
            var productStockService = new ProductStockService(mockRepository.Object, mockMapper.Object);
            var stocks = new List<ProductStock> { new ProductStock { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 } };
            var stockDtos = new List<ProductStockDto> { new ProductStockDto { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 } };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(stocks);
            mockMapper.Setup(mapper => mapper.MapToDtoList(stocks)).Returns(stockDtos);

            var result = await productStockService.GetAllAsync().ConfigureAwait(false);

            Assert.Equal(stockDtos, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnProductStockWhenProductStockExists()
        {
            var mockRepository = new Mock<IProductStockRepository>();
            var mockMapper = new Mock<IMapper<ProductStock, ProductStockDto>>();
            var productStockService = new ProductStockService(mockRepository.Object, mockMapper.Object);
            var stock = new ProductStock { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 };
            var stockDto = new ProductStockDto { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 };
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(stock);
            mockMapper.Setup(mapper => mapper.MapToDto(stock)).Returns(stockDto);

            var result = await productStockService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Equal(stockDto, result);
        }

        [Fact]
        public async Task GetByIdAsyncShouldReturnNullWhenProductStockDoesNotExist()
        {
            var mockRepository = new Mock<IProductStockRepository>();
            var mockMapper = new Mock<IMapper<ProductStock, ProductStockDto>>();
            var productStockService = new ProductStockService(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((ProductStock)null!);

            var result = await productStockService.GetByIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetStockByProductIdAsyncShouldReturnProductStockWhenProductStockExists()
        {
            var mockRepository = new Mock<IProductStockRepository>();
            var mockMapper = new Mock<IMapper<ProductStock, ProductStockDto>>();
            var productStockService = new ProductStockService(mockRepository.Object, mockMapper.Object);
            var stock = new ProductStock { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 };
            var stockDto = new ProductStockDto { Id = 1, ProductId = 1, QuantityOnHand = 100, QuantitySold = 50, QuantityReserved = 20 };
            mockRepository.Setup(repo => repo.GetStockByProductIdAsync(1)).ReturnsAsync(stock);
            mockMapper.Setup(mapper => mapper.MapToDto(stock)).Returns(stockDto);

            var result = await productStockService.GetStockByProductIdAsync(1).ConfigureAwait(false);

            Assert.Equal(stockDto, result);
        }

        [Fact]
        public async Task GetStockByProductIdAsyncShouldReturnNullWhenProductStockDoesNotExist()
        {
            var mockRepository = new Mock<IProductStockRepository>();
            var mockMapper = new Mock<IMapper<ProductStock, ProductStockDto>>();
            var productStockService = new ProductStockService(mockRepository.Object, mockMapper.Object);
            mockRepository.Setup(repo => repo.GetStockByProductIdAsync(1)).ReturnsAsync((ProductStock)null!);

            var result = await productStockService.GetStockByProductIdAsync(1).ConfigureAwait(false);

            Assert.Null(result);
        }
    }
}
