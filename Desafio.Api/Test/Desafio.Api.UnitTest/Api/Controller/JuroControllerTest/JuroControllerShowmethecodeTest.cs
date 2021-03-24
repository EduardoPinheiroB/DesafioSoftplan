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

namespace Desafio.Api.UnitTest.Api.Controller.JuroControllerJuroControllerTest
{
    public class JuroControllerShowmethecodeTest
    {
        private readonly Mock<ILogger<JuroController>> loggerMock;
        private readonly Mock<IBuscarTaxaJurosUseCase> taxaJurosUseCaseMock;
        private readonly Mock<ICalcularTaxaJurosUseCase> calcularTaxaJurosUseCaseMock;
        private readonly JuroController juroController;

        public JuroControllerShowmethecodeTest()
        {
            this.loggerMock = new Mock<ILogger<JuroController>>();
            this.taxaJurosUseCaseMock = new Mock<IBuscarTaxaJurosUseCase>();
            this.calcularTaxaJurosUseCaseMock = new Mock<ICalcularTaxaJurosUseCase>();

            juroController = new JuroController(loggerMock.Object, taxaJurosUseCaseMock.Object, calcularTaxaJurosUseCaseMock.Object);
        }

        [Fact]
        public void Showmethecode_FluxoSucesso_OkObjectResult()
        {
            //Arrange

            //Act
            var resultado = juroController.Showmethecode();

            //Assert
            var tipoResultado = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal("https://github.com/EduardoPinheiroB/DesafioSoftplan", tipoResultado.Value);
        }
    }
}
