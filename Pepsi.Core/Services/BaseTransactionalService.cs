using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;


public class BaseTransactionalService<TEntity, TDto>(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    : ITransactionalService<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    public virtual async Task<int> AddAsync(TDto dto)
    {
        var entity = mapper.MapToEntity(dto);
        return await repository.AddAsync(entity).ConfigureAwait(false);
    }

    public virtual async Task UpdateAsync(TDto dto)
    {
        var entity = mapper.MapToEntity(dto);
        await repository.UpdateAsync(entity).ConfigureAwait(false);
    }

    public virtual async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id).ConfigureAwait(false);
    }
}
