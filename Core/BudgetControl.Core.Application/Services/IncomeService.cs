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
    public class IncomeService : IIncomeService
    {
        private IIncomeRepository _incomeRepository;

        private IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository ?? throw new ArgumentNullException(nameof(incomeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(IncomeDTO incomeDto)
        {
            var mapIncome = _mapper.Map<Income>(incomeDto);
            await _incomeRepository.Create(mapIncome);
        }

        public async Task Delete(IncomeDTO dto)
        {
            var mapIncome = _mapper.Map<Income>(dto);
            await _incomeRepository.Delete(mapIncome);
        }

        public async Task<IEnumerable<IncomeDTO>> GetAll()
        {
            var result = await _incomeRepository.Get();

            return _mapper.Map<IEnumerable<IncomeDTO>>(result);
        }

        public async Task<IncomeDTO> GetById(int id)
        {
            var result = await _incomeRepository.GetById(id);

            return _mapper.Map<IncomeDTO>(result);
        }

        public async Task<IEnumerable<IncomeDTO>> GetByMonthAndYear(int month, int year)
        {
            var result = await _incomeRepository.GetByMonthAndYear((Months)month, year);

            return _mapper.Map<IEnumerable<IncomeDTO>>(result);
        }

        public async Task Update(IncomeDTO incomeDto)
        {
            var mapIncome = _mapper.Map<Income>(incomeDto);
            await _incomeRepository.Update(mapIncome);
        }
    }
}
