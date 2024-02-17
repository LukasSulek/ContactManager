using ECoding_MVC_app.Models.Domain;
using ECoding_MVC_app.Models.DTO;

namespace ECoding_MVC_app.Services
{
    public interface IService<TModel, TDto, TInsertDto, TUpdateDto, TDeleteDto>
        where TModel : IIdentifiable
        where TDto : IDTO
        where TInsertDto : IDTO
        where TUpdateDto : IDTO
        where TDeleteDto : IDTO
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> InsertSingleAsync(TModel model);
        Task DeleteByIdAsync(Guid id);
        Task<TDto> UpdateByIdAsync(Guid id, TUpdateDto updateDto);
    }
}
