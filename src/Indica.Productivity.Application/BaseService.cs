using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Shared.Interfaces;
using System.Linq.Expressions;

namespace Indica.Productivity.Application
{
    public class BaseService<T, Y> : IBaseService<T, Y>
        where T : EntityBaseDTO, new()
        where Y : EntityBase, new()
    {
        private readonly IBaseRepository<Y> _repository;
        private readonly IMapper _mapper;
        private readonly IFileParser _fileParser;

        public BaseService(IBaseRepository<Y> repository, IMapper mapper, IFileParser fileParser)
        {
            _repository = repository;
            _mapper = mapper;
            _fileParser = fileParser;
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

        public virtual async Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<Y, bool>>>(expression);
            var entity = await _repository.GetByExpressionAsync(mappedExpression);
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

        public virtual async Task<int> DeleteRangeAsync(List<T> lista)
        {
            var entitiesMapped = _mapper.Map<List<Y>>(lista);
            return await _repository.DeleteRangeAsync(entitiesMapped);
        }

        public virtual async Task<int> AddRangeAsync(Stream arquivo, string filename)
        {
            var entities = _fileParser.ParseByFilepath<T>(arquivo, filename);
            return await AddRangeAsync(entities);
        }
    }
}
