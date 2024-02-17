using AutoMapper;
using ECoding_MVC_app.DatabaseContext;
using ECoding_MVC_app.Models.Domain;
using ECoding_MVC_app.Models.DTO;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace ECoding_MVC_app.Services
{
    public class Service<TModel, TDto, TInsertDto, TUpdateDto, TDeleteDto>
        : IService<TModel, TDto, TInsertDto, TUpdateDto, TDeleteDto>
        where TModel : class, IIdentifiable
        where TDto : IDTO
        where TInsertDto : IDTO
        where TUpdateDto : IDTO
        where TDeleteDto : IDTO
    {
        protected readonly IAppDbContext _db;
        protected readonly IMapper _mapper;


        public Service(IAppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            try
            {
                IQueryable<TModel> entities = _db.Set<TModel>();

                IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities);

                if (dtos != null)
                {
                    return dtos;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Retrieved list od dtos is null: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }



        public async Task<TDto> GetByIdAsync(Guid id)
        {
            try
            {
                IQueryable<TModel> entities = _db.Set<TModel>();

                TModel model = await entities.SingleOrDefaultAsync(entity => entity.Id == id);

                if (model == null)
                {
                    throw new NotFoundException($"Entity with ID '{id}' not found.");
                }

                TDto dto = _mapper.Map<TDto>(model);

                return dto;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (NoSuchElementException ex)
            {
                throw new NotFoundException($"Element with ID '{id}' not found.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }



        public async Task<TDto> InsertSingleAsync(TModel model)
        {
            try
            {
                _db.Set<TModel>().Add(model);

                await _db.SaveChangesAsync();

                TDto dto = _mapper.Map<TDto>(model);

                return dto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task DeleteByIdAsync(Guid id)
        {
            try
            {
                IQueryable<TModel> entities = _db.Set<TModel>();

                TModel model = await entities.SingleOrDefaultAsync(entity => entity.Id == id);

                if (model == null)
                {
                    throw new NotFoundException($"Entity with ID '{id}' not found.");
                }

                _db.Set<TModel>().Remove(model);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public async Task<TDto> UpdateByIdAsync(Guid id, TUpdateDto updateDto)
        {
            try
            {
                IQueryable<TModel> entities = _db.Set<TModel>();

                TModel model = await entities.SingleOrDefaultAsync(entity => entity.Id == id);

                if (model == null)
                {
                    throw new NotFoundException($"Entity with ID '{id}' not found.");
                }

                _mapper.Map(updateDto, model);

                await _db.SaveChangesAsync();

                TDto updatedDto = _mapper.Map<TDto>(model);

                return updatedDto;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database error during update: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }
    }
}
