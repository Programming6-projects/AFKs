using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper<OrderItem, OrderItemDto> _mapper;

    public OrderItemService(
        IOrderItemRepository orderItemRepository,
        IMapper<OrderItem, OrderItemDto> mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
    {
        var orderItems = await _orderItemRepository.GetAllAsync().ConfigureAwait(false);
        return _mapper.MapToDtoList(orderItems);
    }

    public async Task<OrderItemDto?> GetByIdAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id).ConfigureAwait(false);
        return orderItem == null ? null : _mapper.MapToDto(orderItem);
    }

    public async Task<int> AddAsync(OrderItemDto entity)
    {
        var orderItem = _mapper.MapToEntity(entity);
        return await _orderItemRepository.AddAsync(orderItem).ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderItemDto entity)
    {
        var orderItem = _mapper.MapToEntity(entity);
        await _orderItemRepository.UpdateAsync(orderItem).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await _orderItemRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId).ConfigureAwait(false);
        return _mapper.MapToDtoList(orderItems);
    }
}
