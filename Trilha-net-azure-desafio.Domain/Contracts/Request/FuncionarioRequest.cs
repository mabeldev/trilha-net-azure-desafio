namespace Trilha_net_azure_desafio.Domain.Contracts.Request
{
    public class FuncionarioRequest
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Ramal { get; set; }
        public string EmailProfissional { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTimeOffset? DataAdmissao { get; set; }
    }
}
