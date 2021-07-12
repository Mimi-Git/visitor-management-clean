using Application.Features.Employees;
using Application.Features.Visitors;
using Application.Features.Visits;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Visitor, VisitorDto>().ReverseMap();

            CreateMap<Visit, VisitDto>().ReverseMap();
        }
    }
}