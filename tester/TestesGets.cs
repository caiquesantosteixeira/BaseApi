using Base.Domain.Entidades;
using Base.Domain.Repositorios;
using Base.Domain.Services;
using Base.Infra.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tester
{

    public class TestesGets
    {

        [SetUp]
        public void BeforeTest()
        {
            Console.WriteLine("BeforeTest");

        }

        [Test]
        [TestCase(1)]
        public void TestDeposito_NulidadeGellAllByIdCliente(int id)
        {
            var productId = 1;
            var expected = "AAA";
            var deposito = new Deposito() { Id = 1, Valor = 10 };

            Mock<IDepositoService> mock = new Mock<IDepositoService>();
            mock.Setup(m => m.GetById(1)).Returns(Task.FromResult(deposito)).Verifiable();

            mock.Verify();
            //Assert.IsTrue(teste != null);
        }


    }
}
