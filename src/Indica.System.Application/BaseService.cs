using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain;
using Indica.System.Domain.Entities;

namespace Indica.System.Application
{
    public class BaseService<T, Y> : IBaseService<T, Y>
        where T : EntityBaseDTO
        where Y : class
    {
        private readonly IBaseRepository<Y> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<Y> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            var result = entity.Validate();
            if (result.Count != 0)
            {
                throw new InvalidOperationException("Aconteceu um erro de validação!"); // TODO: passar detalhes do erro
            }

            var entityMapped = _mapper.Map<Y>(entity);
            return await _repository.AddAsync(entityMapped);
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(entities);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            var result = entity.Validate();
            if (result.Count != 0)
            {
                throw new InvalidOperationException("Aconteceu um erro de validação!"); // TODO: passar detalhes do erro
            }

            var entityMapped = _mapper.Map<Y>(entity);
            return await _repository.UpdateAsync(entityMapped);
        }
    }
}
