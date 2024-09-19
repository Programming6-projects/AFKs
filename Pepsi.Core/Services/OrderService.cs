using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper<Order, OrderDto> _mapper;
    private readonly IClientService _clientService;
    private readonly IVehicleService _vehicleService;
    private readonly IOrderItemService _orderItemService;

    public OrderService(
        IOrderRepository orderRepository,
        IMapper<Order, OrderDto> mapper,
        IClientService clientService,
        IVehicleService vehicleService,
        IOrderItemService orderItemService)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _clientService = clientService;
        _vehicleService = vehicleService;
        _orderItemService = orderItemService;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync().ConfigureAwait(false);
        var orderDtos = _mapper.MapToDtoList(orders);
        await PopulateOrderDetails(orderDtos).ConfigureAwait(false);
        return orderDtos;
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (order == null)
        {
            return null;
        }

        var orderDto = _mapper.MapToDto(order);
        await PopulateOrderDetails(new[] { orderDto }).ConfigureAwait(false);
        return orderDto;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByClientIdAsync(int clientId)
    {
        var orders = await _orderRepository.GetOrdersByClientIdAsync(clientId).ConfigureAwait(false);
        var orderDtos = _mapper.MapToDtoList(orders);
        await PopulateOrderDetails(orderDtos).ConfigureAwait(false);
        return orderDtos;
    }

    public async Task<int> AddAsync(OrderDto entity)
    {
        var order = _mapper.MapToEntity(entity);
        return await _orderRepository.AddAsync(order).ConfigureAwait(false);
    }

    public async Task UpdateAsync(OrderDto entity)
    {
        var order = _mapper.MapToEntity(entity);
        await _orderRepository.UpdateAsync(order).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await _orderRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    private async Task PopulateOrderDetails(IEnumerable<OrderDto> orderDtos)
    {
        foreach (var orderDto in orderDtos)
        {
            orderDto.Client = await _clientService.GetByIdAsync(orderDto.ClientId).ConfigureAwait(false);
            orderDto.Vehicle = await _vehicleService.GetByIdAsync(orderDto.VehicleId).ConfigureAwait(false);
            orderDto.Items = await _orderItemService.GetOrderItemsByOrderIdAsync(orderDto.Id).ConfigureAwait(false);
        }
    }
}
