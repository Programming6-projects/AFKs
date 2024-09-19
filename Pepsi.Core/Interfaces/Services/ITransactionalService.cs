using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface ITransactionalService<TDto> where TDto : BaseDto
{
    Task<int> AddAsync(TDto entity);
    Task UpdateAsync(TDto entity);
    Task DeleteAsync(int id);
}
