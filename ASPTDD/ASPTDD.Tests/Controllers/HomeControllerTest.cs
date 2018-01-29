using ASPTDD.Controllers;
using ASPTDD.Models;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASPTDD.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IContatoService> _mockContatoService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContatoService = new Mock<IContatoService>();
            _controller = new HomeController(_mockContatoService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockContatoService.VerifyAll();
        }

        [TestMethod]
        public void Index_RetornoEsperadoView()
        {
            var contatos = new List<Contato>
            {
                new Contato()
                {
                    Id = 1,
                    Nome = "Andrey",
                    Sobrenome = "M. Medeiros Pinto",
                    Email = "anddxd@hotmail.com"
                }
            };

            _mockContatoService.Setup(x => x.ObterTodosContatos()).Returns(contatos);

            var modelEsperada = new List<ContatoViewModel>();
            foreach (var contato in contatos)
            {
                modelEsperada.Add(new ContatoViewModel()
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Sobrenome = contato.Sobrenome,
                    Email = contato.Sobrenome
                });
            }
            var resultado = _controller.Index() as ViewResult;
            var modelAtual = resultado.Model as List<ContatoViewModel>;
            for (int i = 0; i < modelAtual.Count; i++)
            {
                Assert.AreEqual(modelEsperada[i].Id, modelAtual[i].Id);
                Assert.AreEqual(modelEsperada[i].Nome, modelEsperada[i].Nome);
                Assert.AreEqual(modelEsperada[i].Sobrenome, modelEsperada[i].Sobrenome);
                Assert.AreEqual(modelEsperada[i].Email, modelEsperada[i].Email);
            }
        }
    }
}
