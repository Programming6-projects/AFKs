using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IMapper<Order, OrderDto> mapper,
    IClientService clientService,
    IVehicleService vehicleService,
    IOrderItemService orderItemService)
    : IOrderService
{
    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await orderRepository.GetAllAsync().ConfigureAwait(false);
        var orderDtos = mapper.MapToDtoList(orders);
        IEnumerable<OrderDto> allAsync = orderDtos.ToList();
        await PopulateOrderDetails(allAsync).ConfigureAwait(false);
        return allAsync;
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await orderRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (order == null)
        {
            return null;
        }

        var orderDto = mapper.MapToDto(order);
        await PopulateOrderDetails(new[] { orderDto }).ConfigureAwait(false);
        return orderDto;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByClientIdAsync(int clientId)
    {
        var orders = await orderRepository.GetOrdersByClientIdAsync(clientId).ConfigureAwait(false);
        var orderDtos = mapper.MapToDtoList(orders);
        IEnumerable<OrderDto> ordersByClientIdAsync = orderDtos.ToList();
        await PopulateOrderDetails(ordersByClientIdAsync).ConfigureAwait(false);
        return ordersByClientIdAsync;
    }

    public async Task<int> AddAsync(OrderDto dto)
    {
        var order = mapper.MapToEntity(dto);
        return await orderRepository.AddAsync(order).ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderDto dto)
    {
        var order = mapper.MapToEntity(dto);
        await orderRepository.UpdateAsync(order).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await orderRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    private async Task PopulateOrderDetails(IEnumerable<OrderDto> orderDtos)
    {
        foreach (var orderDto in orderDtos)
        {
            orderDto.Client = await clientService.GetByIdAsync(orderDto.ClientId).ConfigureAwait(false);
            orderDto.Vehicle = await vehicleService.GetByIdAsync(orderDto.VehicleId).ConfigureAwait(false);
            orderDto.Items = await orderItemService.GetOrderItemsByOrderIdAsync(orderDto.Id).ConfigureAwait(false);
        }
    }
}
