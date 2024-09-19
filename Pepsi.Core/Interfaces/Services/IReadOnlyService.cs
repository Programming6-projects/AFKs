using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface IReadOnlyService<TDto> where TDto : BaseDto
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(int id);
}
