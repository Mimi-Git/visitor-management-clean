using Application.Features.Employees;
using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.UpdateEmployee;
using Application.Features.Visitors;
using Application.Features.Visitors.Commands.CreateVisitor;
using Application.Features.Visitors.Commands.UpdateVisitor;
using Application.Features.Visits;
using Application.Features.Visits.Commands.CreateVisit;
using Application.Features.Visits.Commands.UpdateVisit;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();

            CreateMap<Visitor, VisitorDto>().ReverseMap();
            CreateMap<Visitor, CreateVisitorCommand>().ReverseMap();
            CreateMap<Visitor, UpdateVisitorCommand>().ReverseMap();

            CreateMap<Visit, VisitDto>().ReverseMap();
            CreateMap<Visit, CreateVisitCommand>().ReverseMap();
            CreateMap<Visit, UpdateVisitCommand>().ReverseMap();
        }
    }
}