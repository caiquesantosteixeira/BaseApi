using Base.Domain.Commands;
using Base.Domain.Commands.Cliente;
using Base.Domain.Handler;
using Base.Domain.Repositorios;
using Base.Domain.Retornos;
using Base.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Base.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]

    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {



        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetAll([FromServices] IClientesService service)
        {
            try
            {
                var dados = await service.GetAll();
                return Ok(new Retorno(true, "Dados GetAll", dados));
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao listar GetById", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }



        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id, [FromServices] IClientesService service)
        {
            try
            {
                var dados = await service.GetById(id);
                return Ok(new Retorno(true, "Dados GetById", dados));
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao listar GetById", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Consulta o cliente passando o CpfCnpj
        /// </summary>
        /// <param name="CpfCnpj"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet("CpfCnpj/{CpfCnpj}")]
        [Authorize]
        public async Task<IActionResult> GetByCpfCnpj(string CpfCnpj, [FromServices] IClientesService service)
        {
            try
            {
                var dados = await service.GetCpfCnpj(CpfCnpj);
                return Ok(new Retorno(true, "Dados GetByTenant", dados));
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao listar GetByTenant", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCadastrarCommand menuCommand, [FromServices] ClienteHandler handler)
        {
            try
            {
                var retorno = (Retorno)await handler.Handle(menuCommand);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao efetuar o Post", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ClienteAtualizarCommand menuCommand, [FromServices] ClienteHandler handler)
        {
            try
            {
                var retorno = (Retorno)await handler.Handle(menuCommand);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao efetuar o Put", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, [FromServices] ICliente repository)
        {
            try
            {
                var dados = await repository.Excluir(id);
                if (dados.Sucesso == false)
                {
                    return BadRequest(dados);
                }
                else
                {
                    return Ok(dados);
                }
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao Excluir o Menu", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
