using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trilha_net_azure_desafio.Domain.Contracts.Request;
using Trilha_net_azure_desafio.Domain.Contracts.Response;
using Trilha_net_azure_desafio.Domain.Entities;
using Trilha_net_azure_desafio.Domain.Entities.Enums;
using Trilha_net_azure_desafio.Domain.Interfaces;

namespace Trilha_net_azure_desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioLogRepository _funcionarioLogRepository;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IFuncionarioLogRepository funcionarioLogRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _funcionarioLogRepository = funcionarioLogRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Através dessa rota você será capaz de cadastrar um Funcionario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] FuncionarioRequest request)
        {
            var entity = _mapper.Map<Funcionario>(request);
            await _funcionarioRepository.AddAsync(entity);

            //log
            var logentity = _mapper.Map<FuncionarioLog>(request);
            logentity.TipoAcao = TipoAcao.Inclusao;
            logentity.Timestamp = DateTime.Now;
            await _funcionarioLogRepository.AddAsync(logentity);


            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar uma listagem de Funcionarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        public async Task<ActionResult<List<FuncionarioResponse>>> GetAsync()
        {
            var entities = await _funcionarioRepository.ListAsync();
            var response = _mapper.Map<IEnumerable<FuncionarioResponse>>(entities);
            return Ok(response);
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar uma listagem de Funcionarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet("log")]
        public async Task<ActionResult<List<FuncionarioResponse>>> GetLogAsync()
        {
            var entities = await _funcionarioLogRepository.ListAsync();
            var response = _mapper.Map<IEnumerable<FuncionarioLogResponse>>(entities);
            return Ok(response);
        }

        /// <summary>
        /// Através dessa rota você será capaz de buscar um Funcionario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<FuncionarioResponse>>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _funcionarioRepository.FindAsync(id);
            var response = _mapper.Map<FuncionarioResponse>(entity);
            return Ok(response);
        }

        /// <summary>
        /// Através dessa rota você será capaz de alterar um Funcionario
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] FuncionarioRequest request)
        {
            var entity = _mapper.Map<Funcionario>(request);
            entity.Id = id;
            await _funcionarioRepository.EditAsync(entity);

            //log
            var logentity = _mapper.Map<FuncionarioLog>(request);
            logentity.TipoAcao = TipoAcao.Atualizacao;
            logentity.Timestamp = DateTime.Now;
            await _funcionarioLogRepository.AddAsync(logentity);


            return NoContent();
        }

        /// <summary>
        /// Através dessa rota você será capaz de deletar um Funcionario
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var dbEntity = _funcionarioRepository.FindAsync(id);
            var entity = dbEntity.Result;

            //log
            var logentity = _mapper.Map<FuncionarioLog>(entity);
            logentity.TipoAcao = TipoAcao.Remocao;
            logentity.Timestamp = DateTime.Now;
            await _funcionarioLogRepository.AddAsync(logentity);

            await _funcionarioRepository.RemoveAsync(entity);
            return NoContent();
        }
    }
}
