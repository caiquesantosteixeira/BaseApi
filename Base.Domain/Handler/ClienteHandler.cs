using Base.Domain.Commands;
using Base.Domain.Commands.Cliente;
using Base.Domain.Commands.Interfaces;
using Base.Domain.Entidades;
using Base.Domain.Handler.Interface;
using Base.Domain.Repositorios;
using Base.Domain.Retornos;
using Flunt.Notifications;
using System;
using System.Threading.Tasks;

namespace Base.Domain.Handler.Cliente
{
    public class ClienteHandler: Notifiable,
        IHandler<ClienteCadastrarCommand>,
         IHandler<ClienteAtualizarCommand>
    {
        private readonly ICliente _repository;
        public ClienteHandler(ICliente repository)
        {
            _repository = repository;            

        }

        public async Task<ICommandResult> Handle(ClienteCadastrarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

            return await Cadastrar(command);           
        }

        public async Task<ICommandResult> Handle(ClienteAtualizarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

           return await Atualizar(command);
        }
    }
}
