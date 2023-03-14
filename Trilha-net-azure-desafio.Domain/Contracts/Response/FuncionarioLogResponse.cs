using Trilha_net_azure_desafio.Domain.Entities.Enums;

namespace Trilha_net_azure_desafio.Domain.Contracts.Response
{
    public class FuncionarioLogResponse : FuncionarioResponse
    {
        public TipoAcao TipoAcao { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
