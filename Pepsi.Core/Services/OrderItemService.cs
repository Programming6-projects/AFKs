using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderItemService(
    IOrderItemRepository orderItemRepository,
    IMapper<OrderItem, OrderItemDto> mapper)
    : IOrderItemService
{
    public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
    {
        var orderItems = await orderItemRepository.GetAllAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(orderItems);
    }

    public async Task<OrderItemDto?> GetByIdAsync(int id)
    {
        var orderItem = await orderItemRepository.GetByIdAsync(id).ConfigureAwait(false);
        return orderItem == null ? null : mapper.MapToDto(orderItem);
    }

    public async Task<int> AddAsync(OrderItemDto dto)
    {
        var orderItem = mapper.MapToEntity(dto);
        return await orderItemRepository.AddAsync(orderItem).ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderItemDto dto)
    {
        var orderItem = mapper.MapToEntity(dto);
        await orderItemRepository.UpdateAsync(orderItem).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await orderItemRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderDtoId)
    {
        var orderItems = await orderItemRepository.GetOrderItemsByOrderIdAsync(orderDtoId).ConfigureAwait(false);
        return mapper.MapToDtoList(orderItems);
    }
}
