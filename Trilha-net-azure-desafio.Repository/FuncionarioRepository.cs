using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trilha_net_azure_desafio.Domain.Entities;
using Trilha_net_azure_desafio.Domain.Interfaces;

namespace Trilha_net_azure_desafio.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ApiContext apiContext) : base(apiContext) { }
    }
}
