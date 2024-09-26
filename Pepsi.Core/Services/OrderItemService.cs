using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class OrderItemService(
    IOrderItemRepository orderItemRepository,
    IMapper<OrderItem, OrderItemDto> mapper,
    IMapper<OrderItem, CompleteOrderItemDto> mapperComplete,
    IMapper<Product, ProductDto> productMapper,
    IProductService productService)
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
        var orderItem = await mapper.MapFromCreateToEntity(dto).ConfigureAwait(false);
        return await orderItemRepository.AddAsync(orderItem).ConfigureAwait(false);
    }


    public Task UpdateAsync(OrderItemDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderDtoId)
    {
        var orderItems = await orderItemRepository.GetOrderItemsByOrderIdAsync(orderDtoId).ConfigureAwait(false);

        var items = orderItems.ToList();
        foreach (var orderItem in items)
        {
            if (orderItem.ProductId > 0)
            {
                var product = await productService.GetByIdWithStockAsync(orderItem.ProductId).ConfigureAwait(false);
                if (product != null)
                {
                    orderItem.Product = product;
                }
            }
        }

        return mapperComplete.MapToDtoList(items);
    }

}
