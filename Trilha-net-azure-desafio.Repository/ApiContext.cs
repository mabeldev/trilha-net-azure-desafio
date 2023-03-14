using Microsoft.EntityFrameworkCore;
using Trilha_net_azure_desafio.Domain.Contracts.Request;
using Trilha_net_azure_desafio.Domain.Entities;

namespace Trilha_net_azure_desafio.Repository
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioLog> FuncionarioLogs { get; set; }        
    }
}