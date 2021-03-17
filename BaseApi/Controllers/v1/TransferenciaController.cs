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
    [Authorize]
    [Produces("application/json")]
    public class TransferenciaController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll(int idCliente, [FromServices] ITransferenciaService service)
        {
            try
            {
                var dados = await service.GetAll(idCliente);
                return Ok(new Retorno(true, "Dados GetAll", dados));
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao listar GetById", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet()]
        [Route("GetAllRecebidas")]
        public async Task<IActionResult> GetAllRecebidas(int idClienteRecebidas, [FromServices] ITransferenciaService service)
        {
            try
            {
                var dados = await service.GetAllRecebidas(idClienteRecebidas);
                return Ok(new Retorno(true, "Dados GetAll", dados));
            }
            catch (Exception ex)
            {
                //GerarLog("Erro ao listar GetById", ex: ex);
                return StatusCode(500, ex.ToString());
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, [FromServices] ITransferenciaService service)
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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransferenciaCadastrarCommand menuCommand, [FromServices] TransferenciaHandler handler)
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
        public async Task<IActionResult> Put([FromBody] TransferenciaAtualizarCommand menuCommand, [FromServices] TransferenciaHandler handler)
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
