using Trilha_net_azure_desafio.Domain.Entities;
using Trilha_net_azure_desafio.Domain.Entities.Enums;

namespace Trilha_net_azure_desafio.Domain.Contracts.Request
{
    public class FuncionarioLogRequest : FuncionarioRequest
    {
        public TipoAcao TipoAcao { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
