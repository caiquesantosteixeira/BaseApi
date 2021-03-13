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
    public class DepositoHandler: Notifiable,
        IHandler<DepositoCadastrarCommand>,
         IHandler<DepositoAtualizarCommand>
    {
        private readonly IDeposito _repository;
        public DepositoHandler(IDeposito repository)
        {
            _repository = repository;            

        }

        public async Task<ICommandResult> Handle(DepositoCadastrarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

            return await Cadastrar(command);           
        }

        public async Task<ICommandResult> Handle(DepositoAtualizarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

           return await Atualizar(command);
        }

        private async Task<Retorno> Cadastrar(DepositoCadastrarCommand command)
        {
            var Deposito = new Entidades.Deposito();
            Deposito.IdCliente = command.IdCliente;
            Deposito.NomeRemetente = command.NomeRemetente??"";

            try
            {
                var ret = await _repository.Cadastrar(Deposito);
                return new Retorno(true, "Cadastrado com sucesso", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao cadastrar o deposito.", "Ocorreu um erro ao cadastrar o deposito.");
            }
        }

        private async Task<Retorno> Atualizar(DepositoAtualizarCommand command)
        {
            var Deposito = new Entidades.Deposito();
            Deposito.Id = command.Id;
            Deposito.IdCliente = command.IdCliente;
            Deposito.NomeRemetente = command.NomeRemetente ?? "";

            try
            {
                var ret = await _repository.Atualizar(Deposito);
                return new Retorno(true, "Ocorreu um erro ao fazer o Deposito.", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao fazer o Deposito.", "Ocorreu um erro ao fazer o Deposito.");
            }
        }
    }
}
