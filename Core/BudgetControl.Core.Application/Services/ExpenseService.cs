using AutoMapper;
using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;

namespace BudgetControl.Core.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository _repository;

        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _repository = expenseRepository ?? throw new ArgumentNullException(nameof(expenseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(ExpenseDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Expense>(outgoingDto);
            await _repository.Create(mapOutgoing);
        }

        public async Task Delete(ExpenseDTO dto)
        {
            var mapOutgoing = _mapper.Map<Expense>(dto);
            await _repository.Delete(mapOutgoing);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAll()
        {
            var result = await _repository.Get();

            return _mapper.Map<IEnumerable<ExpenseDTO>>(result);
        }

        public async Task<ExpenseDTO> GetById(int id)
        {
            var result = await _repository.GetById(id);

            return _mapper.Map<ExpenseDTO>(result);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetByMonthAndYear(int month, int year)
        {
            var result = await _repository.GetByMonthAndYear(month, year);

            return _mapper.Map<IEnumerable<ExpenseDTO>>(result);
        }

        public async Task Update(ExpenseDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Expense>(outgoingDto);
            await _repository.Update(mapOutgoing);
        }
    }
}
