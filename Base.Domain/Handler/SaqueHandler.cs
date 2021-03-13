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

namespace Base.Domain.Handler
{
    public class SaqueHandler: Notifiable,
        IHandler<SaqueCadastrarCommand>,
         IHandler<SaqueAtualizarCommand>
    {
        private readonly ISaque _repository;
        public SaqueHandler(ISaque repository)
        {
            _repository = repository;            

        }

        public async Task<ICommandResult> Handle(SaqueCadastrarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

            return await Cadastrar(command);           
        }

        public async Task<ICommandResult> Handle(SaqueAtualizarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

           return await Atualizar(command);
        }

        private async Task<Retorno> Cadastrar(SaqueCadastrarCommand command)
        {
            var Saque = new Entidades.Saque();
            Saque.IdCliente = command.IdCliente;

            try
            {
                var ret = await _repository.Cadastrar(Saque);
                return new Retorno(true, "Cadastrado com sucesso", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao cadastrar o Saque.", "Ocorreu um erro ao cadastrar o Saque.");
            }
        }

        private async Task<Retorno> Atualizar(SaqueAtualizarCommand command)
        {
            var Saque = new Entidades.Saque();
            Saque.Id = command.Id;
            Saque.IdCliente = command.IdCliente;

            try
            {
                var ret = await _repository.Atualizar(Saque);
                return new Retorno(true, "Ocorreu um erro ao fazer o Saque.", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao fazer o Saque.", "Ocorreu um erro ao fazer o Saque.");
            }
        }
    }
}
