using AutoMapper;
using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;

namespace BudgetControl.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var mapCategory = _mapper.Map<Category>(categoryDTO);
            await _repository.Create(mapCategory);
        }

        public async Task Delete(CategoryDTO categoryDTO)
        {
            var mapCategory = _mapper.Map<Category>(categoryDTO);
            await _repository.Delete(mapCategory);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var result = await _repository.Get();

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetByDescription(string description)
        {
            var result = await _repository.GetByDescription(description);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetByName(string name)
        {
            var result = await _repository.GetByName(name);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetByType(int type)
        {
            var result = await _repository.GetByType((CategoryType)type);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var mapCategory = _mapper.Map<Category>(categoryDTO);
            await _repository.Update(mapCategory);
        }
    }
}
