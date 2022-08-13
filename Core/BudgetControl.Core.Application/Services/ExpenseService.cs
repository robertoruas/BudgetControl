using AutoMapper;
using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Application.Interfaces;
using BudgetControl.Core.Domain.Entities;
using BudgetControl.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseRepository _outgoingRepository;

        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository outgoingRepository, IMapper mapper)
        {
            _outgoingRepository = outgoingRepository ?? throw new ArgumentNullException(nameof(outgoingRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(ExpenseDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Expense>(outgoingDto);
            await _outgoingRepository.Create(mapOutgoing);
        }

        public async Task Delete(ExpenseDTO dto)
        {
            var mapOutgoing = _mapper.Map<Expense>(dto);
            await _outgoingRepository.Delete(mapOutgoing);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAll()
        {
            var result = await _outgoingRepository.Get();

            return _mapper.Map<IEnumerable<ExpenseDTO>>(result);
        }

        public async Task<ExpenseDTO> GetById(int id)
        {
            var result = await _outgoingRepository.GetById(id);

            return _mapper.Map<ExpenseDTO>(result);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetByMonthAndYear(int month, int year)
        {
            var result = await _outgoingRepository.GetByMonthAndYear(month, year);

            return _mapper.Map<IEnumerable<ExpenseDTO>>(result);
        }

        public async Task Update(ExpenseDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Expense>(outgoingDto);
            await _outgoingRepository.Update(mapOutgoing);
        }
    }
}
