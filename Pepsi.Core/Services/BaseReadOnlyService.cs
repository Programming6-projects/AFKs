using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class BaseReadOnlyService<TEntity, TDto>(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    : IReadOnlyService<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(entities);
    }

    public virtual async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id).ConfigureAwait(false);
        return entity != null ? mapper.MapToDto(entity) : null;
    }
}
