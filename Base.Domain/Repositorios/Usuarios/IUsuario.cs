using Base.Domain.Commands;
using Base.Domain.Commands.Usuario;
using Base.Domain.DTOs;
using Base.Domain.DTOs.Usuario;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using System.Threading.Tasks;

namespace Base.Domain.Repositorios.Usuarios
{
    public  interface IUsuario
    {
        Task<Retorno> Logar(LoginDTO login);
        Task<UsuarioLogadoDTO> GerarJwtAsync(UsuarioLogadoDTO parcial);      
        Task<Retorno> GetAll();
        Task<Retorno> GetById(string id);
        Task<Retorno> Cadastrar(UsuarioCommand usuario);
        Task<Retorno> Atualizar(UsuarioCommand usuario);
        Task<Retorno> AlterarSenha(AlterarSenhaCommand command);
        Task<Retorno> AlterarSenha(Email email, string novaSenha);
        Task<Retorno> Excluir(string id);
    }
}
