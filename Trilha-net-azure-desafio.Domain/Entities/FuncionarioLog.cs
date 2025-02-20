﻿using Trilha_net_azure_desafio.Domain.Entities.Enums;

namespace Trilha_net_azure_desafio.Domain.Entities
{
    public class FuncionarioLog
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Ramal { get; set; }
        public string EmailProfissional { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTimeOffset? DataAdmissao { get; set; }

        public TipoAcao TipoAcao { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
