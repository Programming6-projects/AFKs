using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class BaseReadOnlyService<TEntity, TDto> : IReadOnlyService<TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper<TEntity, TDto> _mapper;

    public BaseReadOnlyService(IRepository<TEntity> repository, IMapper<TEntity, TDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync().ConfigureAwait(false);
        return _mapper.MapToDtoList(entities);
    }

    public virtual async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);
        return entity != null ? _mapper.MapToDto(entity) : null;
    }
}
