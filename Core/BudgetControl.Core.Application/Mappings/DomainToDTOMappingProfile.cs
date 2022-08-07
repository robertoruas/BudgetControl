﻿using AutoMapper;
using BudgetControl.Core.Application.DTOs;
using BudgetControl.Core.Domain.Entities;

namespace BudgetControl.Core.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Outgoing, OutgoingDTO>().ReverseMap();
        }
    }
}
