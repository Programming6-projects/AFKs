using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IMapper<Order, CompleteOrderDto> mapper,
    IMapper<Order, OrderDto> createOrderMapper,
    IClientService clientService,
    IVehicleService vehicleService,
    IOrderItemService orderItemService)
    : IOrderService
{
    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await orderRepository.GetAllAsync().ConfigureAwait(false);
        var orderDtos = mapper.MapToDtoList(orders);
        IEnumerable<CompleteOrderDto> allAsync = orderDtos.ToList();
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
        IEnumerable<CompleteOrderDto> ordersByClientIdAsync = orderDtos.ToList();
        await PopulateOrderDetails(ordersByClientIdAsync).ConfigureAwait(false);
        return ordersByClientIdAsync;
    }

    public async Task<int> AddAsync(OrderDto dto)
    {
        var order = createOrderMapper.MapToEntity(dto);
        return await orderRepository.AddAsync(order).ConfigureAwait(false);
    }

    public Task UpdateAsync(OrderDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    private async Task PopulateOrderDetails(IEnumerable<CompleteOrderDto> orderDtos)
    {
        foreach (var orderDto in orderDtos)
        {
            orderDto.Client = await clientService.GetByIdAsync(orderDto.ClientId).ConfigureAwait(false);
            orderDto.Vehicle = await vehicleService.GetByIdAsync(orderDto.VehicleId).ConfigureAwait(false);
            orderDto.Items = (IEnumerable<CompleteOrderItemDto>)await orderItemService.GetOrderItemsByOrderIdAsync(orderDto.Id).ConfigureAwait(false);
        }
    }
}
