using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;


public class BaseTransactionalService<TEntity, TDto> : ITransactionalService<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper<TEntity, TDto> _mapper;

    public BaseTransactionalService(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<int> AddAsync(TDto dto)
    {
        var entity = _mapper.MapToEntity(dto);
        return await _repository.AddAsync(entity).ConfigureAwait(false);
    }

    public virtual async Task UpdateAsync(TDto dto)
    {
        var entity = _mapper.MapToEntity(dto);
        await _repository.UpdateAsync(entity).ConfigureAwait(false);
    }

    public virtual async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id).ConfigureAwait(false);
    }
}
