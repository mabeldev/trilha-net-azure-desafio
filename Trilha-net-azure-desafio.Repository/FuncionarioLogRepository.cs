using Trilha_net_azure_desafio.Domain.Entities;
using Trilha_net_azure_desafio.Domain.Interfaces;

namespace Trilha_net_azure_desafio.Repository
{
    public class FuncionarioLogRepository : BaseRepository<FuncionarioLog>, IFuncionarioLogRepository
    {
        public FuncionarioLogRepository(ApiContext apiContext) : base(apiContext) { }
    }
}
