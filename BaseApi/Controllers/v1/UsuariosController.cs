using Base.Domain.Commands.Usuario;
using Base.Domain.Commands.Usuario.Enums;
using Base.Domain.DTOs.Usuario;
using Base.Domain.Handler.Usuario;
using Base.Domain.Repositorios.Usuarios;
using Base.Domain.Retornos;
using Base.Infra.Helpers.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Base.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _repositorioLogin;       

        public UsuariosController(IUsuario repositorioLogin)
        {
            _repositorioLogin = repositorioLogin;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromServices] IUsuario repository)
        {
            try
            {
                var retorno = await repository.GetAll();
                if (retorno.Sucesso == false)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromServices] IUsuario repository, string id)
        {
            try
            {
                var retorno = await repository.GetById(id);
                if (retorno.Sucesso == false)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            try
            {               
                var retorno = (Retorno)await handler.Handle(command, ELogin.CADASTRAR);
                if (retorno.Sucesso == false)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            try
            {
                var retorno = (Retorno) await handler.Handle(command, ELogin.ATUALIZAR);
                if (retorno.Sucesso == false)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ClaimsAuthorize("CADUSUARIOS", "EXCLUIR")]
        public async Task<IActionResult> Delete([FromBody] UsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            try
            {
                var retorno = (Retorno)await handler.Handle(command, ELogin.EXCLUIR);
                if (retorno.Sucesso == false)
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Metodo para Efetuar o Login do Usuário
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost("Logar-Form")]
        public async Task<ActionResult> LoginFrom([FromForm] LoginDTO loginUser)
        {
            return await Logar(loginUser);
        }

        /// <summary>
        /// Metodo para Efetuar o Login do Usuário
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost("Logar")]
        public async Task<ActionResult> LoginBody([FromBody] LoginDTO loginUser)
        {
            return await Logar(loginUser);
        }


        private async Task<ActionResult> Logar(LoginDTO loginUser)
        {
            try
            {
                var retorno = await _repositorioLogin.Logar(loginUser);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno);
                }
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
