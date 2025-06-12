using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain;
using Indica.System.Domain.Entities;
using System.Linq.Expressions;

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

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(entities);
        }

        public virtual async Task<T> GetByIdAsync(int id)
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

        public virtual async Task<List<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<Y, bool>>>(expression);
            var entity = await _repository.GetByExpression(mappedExpression);
            return _mapper.Map<List<T>>(entity);
        }

        public virtual async Task<int> AddRangeAsync(List<T> lista)
        {
            var errosValidacao = lista.SelectMany(item => item.Validate()).ToList();
            if (errosValidacao.Count != 0)
            {
                // TODO: passar detalhes do erro
                throw new InvalidOperationException("Aconteceu um erro de validação!");
            }
            var entityMapped = _mapper.Map<List<Y>>(lista);
            await _repository.AddRangeAsync(entityMapped);
            return lista.Count;
        }

        public virtual async Task<int> UpdateRangeAsync(List<T> lista)
        {
            var errosValidacao = lista.SelectMany(item => item.Validate()).ToList();
            if (errosValidacao.Count != 0)
            {
                // TODO: passar detalhes do erro
                throw new InvalidOperationException("Aconteceu um erro de validação!");
            }
            var entityMapped = _mapper.Map<List<Y>>(lista);
            await _repository.UpdateRangeAsync(entityMapped);
            return lista.Count;
        }

        public async Task<int> AddRangeAsync(Stream arquivo)
        {
            throw new NotImplementedException();
        }
    }
}
