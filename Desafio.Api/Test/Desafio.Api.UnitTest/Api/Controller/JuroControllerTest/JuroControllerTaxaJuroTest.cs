using CSharpFunctionalExtensions;
using Desafio.Api.Controllers;
using Desafio.Application.Interfaces;
using Desafio.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Desafio.Api.UnitTest.Api.Controller.JuroControllerTest
{
    public class JuroControllerTaxaJuroTest
    {
        private readonly Mock<ILogger<JuroController>> loggerMock;
        private readonly Mock<IBuscarTaxaJurosUseCase> taxaJurosUseCaseMock;
        private readonly Mock<ICalcularTaxaJurosUseCase> calcularTaxaJurosUseCaseMock;
        private readonly JuroController juroController;

        public JuroControllerTaxaJuroTest()
        {
            this.loggerMock = new Mock<ILogger<JuroController>>();
            this.taxaJurosUseCaseMock = new Mock<IBuscarTaxaJurosUseCase>();
            this.calcularTaxaJurosUseCaseMock = new Mock<ICalcularTaxaJurosUseCase>();

            juroController = new JuroController(loggerMock.Object, taxaJurosUseCaseMock.Object, calcularTaxaJurosUseCaseMock.Object);
        }

        [Fact]
        public void TaxaJuro_FluxoSucesso_OkObjectResult()
        {
            //Arrange
            taxaJurosUseCaseMock.Setup(f => f.BuscarTaxaJuro())
                .Returns(Result.Success<JuroResult>(new JuroResult { Taxa =  0.1M }));

            //Act
            var resultado = juroController.TaxaJuro();

            //Assert
            var tipoResultado = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(0.1M, tipoResultado.Value);
        }

        [Fact]
        public void TaxaJuro_FluxoInsucesso_BadRequestObjectResult()
        {
            //Arrange
            taxaJurosUseCaseMock.Setup(f => f.BuscarTaxaJuro())
                .Returns(Result.Failure<JuroResult>("Teste Erro"));

            //Act
            var resultado = juroController.TaxaJuro();

            //Assert
            var tipoResultado = Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal("Ocorreu uma falha ao processar a requisição", tipoResultado.Value);
        }

        [Fact]
        public void TaxaJuro_FluxoExcecao_ObjectResult()
        {
            //Arrange
            taxaJurosUseCaseMock.Setup(f => f.BuscarTaxaJuro())
                .Throws(new Exception("Teste Excecao"));

            //Act
            var resultado = juroController.TaxaJuro();

            //Assert
            var tipoResultado = Assert.IsType<ObjectResult>(resultado);
            Assert.Equal(StatusCodes.Status500InternalServerError, tipoResultado.StatusCode);
            Assert.Equal("Ocorreu um erro ao processar a requisição.", tipoResultado.Value);
        }
    }
}
