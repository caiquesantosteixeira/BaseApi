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

        private async Task<Retorno> Cadastrar(ClienteCadastrarCommand command)
        {
            var cliente = await _repository.GetCpfCnpj(command.Cpf);
            if (cliente != null)
                return new Retorno(false, "Cliente já existe", "Cliente já existe");

           

            cliente = new Entidades.Cliente();
            cliente.Nome = command.Nome;
            cliente.Saldo = command.Saldo;
            cliente.Cpf = command.Cpf;

            try
            {
                var ret = await _repository.Cadastrar(cliente);
                return new Retorno(true, "Cadastrado com sucesso", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao cadastrar o cliente.", "Ocorreu um erro ao cadastrar o cliente.");
            }
        }

        private async Task<Retorno> Atualizar(ClienteAtualizarCommand command)
        {
            var cliente = await _repository.GetCpfCnpj(command.Cpf);
            if (cliente != null)
                return new Retorno(false, "Cliente já existe", "Cliente já existe");



            cliente = new Entidades.Cliente();
            cliente.Id = command.Id;
            cliente.Nome = command.Nome;
            cliente.Saldo = command.Saldo;
            cliente.Cpf = command.Cpf;

            try
            {
                var ret = await _repository.Atualizar(cliente);
                return new Retorno(true, "Atualizado com sucesso", ret);
            }
            catch (Exception)
            {
                return new Retorno(false, "Ocorreu um erro ao cadastrar o cliente.", "Ocorreu um erro ao cadastrar o cliente.");
            }
        }
    }
}
