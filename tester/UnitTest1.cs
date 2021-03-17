using Base.Domain.Repositorios;
using Base.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestDeposito_NulidadeGellAllByIdCliente([FromServices] IDepositoService service) 
        {
            var dados = await service.GetAll(1);
            Assert.IsTrue(dados != null);
        }

        [TestMethod]
        public async void TestDeposito_NulidadeGelByIdCliente([FromServices] IDepositoService service)
        {
            var dados = await service.GetById(1);
            Assert.IsTrue(dados != null);
        }

        [TestMethod]
        public async void TestSaque_NulidadeGellAllByIdCliente([FromServices] ISaquesService service)
        {
            var dados = await service.GetAll(1);
            Assert.IsTrue(dados != null);
        }

        [TestMethod]
        public async void TestSaque_NulidadeGelByIdCliente([FromServices] ISaquesService service)
        {
            var dados = await service.GetById(1);
            Assert.IsTrue(dados != null);
        }

        [TestMethod]
        public async void TestTransferencia_NulidadeGellAllByIdCliente([FromServices] ITransferenciaService service)
        {
            var dados = await service.GetAll(1);
            Assert.IsTrue(dados != null);
        }

        [TestMethod]
        public async void TestTransferencia_NulidadeGelByIdCliente([FromServices] ITransferenciaService service)
        {
            var dados = await service.GetById(1);
            Assert.IsTrue(dados != null);
        }

    }
}
