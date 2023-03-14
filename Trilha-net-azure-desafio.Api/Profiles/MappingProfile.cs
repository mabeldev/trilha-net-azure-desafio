using AutoMapper;
using Trilha_net_azure_desafio.Domain.Contracts.Request;
using Trilha_net_azure_desafio.Domain.Contracts.Response;
using Trilha_net_azure_desafio.Domain.Entities;

namespace Trilha_net_azure_desafio.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FuncionarioRequest, Funcionario>().ReverseMap();
            CreateMap<FuncionarioRequest, FuncionarioLog>().ReverseMap();

            CreateMap<FuncionarioResponse, Funcionario>().ReverseMap();
            CreateMap<FuncionarioResponse, FuncionarioLog>().ReverseMap();

            CreateMap<Funcionario, FuncionarioLog>().ReverseMap();


            CreateMap<FuncionarioLogRequest, FuncionarioLog>().ReverseMap();
            CreateMap<FuncionarioLogResponse, FuncionarioLog>().ReverseMap();
        }
    }
}
