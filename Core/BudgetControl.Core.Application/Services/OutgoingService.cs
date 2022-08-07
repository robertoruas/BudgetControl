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
    public class OutgoingService : IOutgoingService
    {
        private IOutgoingRepository _outgoingRepository;

        private readonly IMapper _mapper;

        public OutgoingService(IOutgoingRepository outgoingRepository, IMapper mapper)
        {
            _outgoingRepository = outgoingRepository ?? throw new ArgumentNullException(nameof(outgoingRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(OutgoingDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Outgoing>(outgoingDto);
            await _outgoingRepository.Create(mapOutgoing);
        }

        public async Task Delete(OutgoingDTO dto)
        {
            var mapOutgoing = _mapper.Map<Outgoing>(dto);
            await _outgoingRepository.Delete(mapOutgoing);
        }

        public async Task<IEnumerable<OutgoingDTO>> GetAll()
        {
            var result = await _outgoingRepository.Get();

            return _mapper.Map<IEnumerable<OutgoingDTO>>(result);
        }

        public async Task<OutgoingDTO> GetById(int id)
        {
            var result = await _outgoingRepository.GetById(id);

            return _mapper.Map<OutgoingDTO>(result);
        }

        public async Task<IEnumerable<OutgoingDTO>> GetByMonthAndYear(int month, int year)
        {
            var result = await _outgoingRepository.GetByMonthAndYear((Months)month, year);

            return _mapper.Map<IEnumerable<OutgoingDTO>>(result);
        }

        public async Task Update(OutgoingDTO outgoingDto)
        {
            var mapOutgoing = _mapper.Map<Outgoing>(outgoingDto);
            await _outgoingRepository.Update(mapOutgoing);
        }
    }
}
