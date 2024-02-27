using AutoMapper;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Entities.Miscellaneous;
using AdminProSolutions.Domain.Dtos.Miscellaneous;
using AdminProSolutions.Domain.Entities.Organization;
using AdminProSolutions.Domain.Dtos.Organization;

namespace AdminProSolutions.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();

            CreateMap<Groups, GroupsDto>();
            CreateMap<GroupsDto, Groups>();

            CreateMap<RegisterRequestDto, Users>();
            CreateMap<Users, RegisterRequestDto>();

            CreateMap<GroupsUsers, GroupsUsersDto>();
            CreateMap<GroupsUsersDto, GroupsUsers>();

            CreateMap<FormsAccessTypes, FormAccessTypesDto>();
            CreateMap<FormAccessTypesDto, FormsAccessTypes>();

            CreateMap<Forms, FormDto>();
            CreateMap<FormDto, Forms>();

            CreateMap<GroupFormsAccessTypes, GroupFormAccessTypesDto>();
            CreateMap<GroupFormAccessTypesDto, GroupFormsAccessTypes>();

            CreateMap<AccessTypes, AccessTypeDto>();
            CreateMap<AccessTypeDto, AccessTypes>();

            CreateMap<Audit, AuditDto>();
            CreateMap<AuditDto, Audit>();

            CreateMap<Clients, ClientDto>();
            CreateMap<ClientDto, Clients>();

            CreateMap<Employees, EmployeeDto>();
            CreateMap<EmployeeDto, Employees>();
        }
    }
}
