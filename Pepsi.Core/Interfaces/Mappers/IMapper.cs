using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;

namespace Pepsi.Core.Interfaces.Mappers;

public interface IMapper<TEntity, TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    TDto MapToDto(TEntity entity);
    TEntity MapToEntity(TDto dto);
    Task<TEntity> MapFromCreateToEntity(TDto dto);
    IEnumerable<TDto> MapToDtoList(IEnumerable<TEntity> entities);
    IEnumerable<TEntity> MapToEntityList(IEnumerable<TDto> dtos);
}
