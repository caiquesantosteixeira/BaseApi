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
    public class TransferenciaHandler: Notifiable,
        IHandler<TransferenciaCadastrarCommand>,
         IHandler<TransferenciaAtualizarCommand>
    {
        private readonly ITransferencia _repository;
        public TransferenciaHandler(ITransferencia repository)
        {
            _repository = repository;            

        }

        public async Task<ICommandResult> Handle(TransferenciaCadastrarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

            return await Cadastrar(command);           
        }

        public async Task<ICommandResult> Handle(TransferenciaAtualizarCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new Retorno(false, "Dados Inválidos!", command.Notifications);

           return await Atualizar(command);
        }

        private async Task<Retorno> Cadastrar(TransferenciaCadastrarCommand command)
        {
            var Transferencia = new Entidades.Transferencia();

            Transferencia.IdClienteRemetente = command.IdClienteRemetente;
            Transferencia.IdClienteDestinatario = command.IdClienteDestinatario;
            Transferencia.Valor = command.Valor;
            Transferencia.Data = DateTime.Now;
            try
            {
                var ret = await _repository.Cadastrar(Transferencia);
                return new Retorno(true, "Cadastrado com sucesso", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao cadastrar o Saque.", "Ocorreu um erro ao cadastrar o Saque.");
            }
        }

        private async Task<Retorno> Atualizar(TransferenciaAtualizarCommand command)
        {
            var Transferencia = new Entidades.Transferencia();
            Transferencia.Id = command.Id;
            Transferencia.IdClienteRemetente = command.IdClienteRemetente;
            Transferencia.IdClienteDestinatario = command.IdClienteDestinatario;
            Transferencia.Valor = command.Valor;
            Transferencia.Data = DateTime.Now;

            try
            {
                var ret = await _repository.Atualizar(Transferencia);
                return new Retorno(true, "Ocorreu um erro ao fazer o Saque.", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao fazer o Saque.", "Ocorreu um erro ao fazer o Saque.");
            }
        }
    }
}
