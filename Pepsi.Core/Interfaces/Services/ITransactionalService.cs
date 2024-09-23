using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface ITransactionalService<in TDto> where TDto : BaseDto
{
    Task<int> AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(int id);
}
