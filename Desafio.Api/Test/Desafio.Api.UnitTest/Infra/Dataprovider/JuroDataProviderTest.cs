using CSharpFunctionalExtensions;
using Desafio.Infra.Adapters.Interfaces;
using Desafio.Infra.DataProvider;
using Moq;
using Xunit;

namespace Desafio.Api.UnitTest.Infra.Dataprovider
{
    public class JuroDataProviderTest
    {
        private readonly Mock<IApiBuscarTaxaJuroAdapter> apiBuscarTaxaJuroAdapterMock;
        private readonly JuroDataProvider juroDataProvider;

        public JuroDataProviderTest()
        {
            apiBuscarTaxaJuroAdapterMock = new Mock<IApiBuscarTaxaJuroAdapter>();
            juroDataProvider = new JuroDataProvider(apiBuscarTaxaJuroAdapterMock.Object);
        }

        [Fact]
        public void BuscarTaxaJuro_FluxoSucesso_ResultSuccess()
        {
            //Arrange

            //Act
            var resultado = juroDataProvider.BuscarTaxaJuro();

            //Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal(0.1M, resultado);
        }

        [Fact]
        public void ConsultarApiTaxaJuro_FluxoSucesso_ResultSuccess()
        {
            //Arrange
            apiBuscarTaxaJuroAdapterMock.Setup(f => f.BuscarTaxaJuro())
                .ReturnsAsync(Result.Success<decimal>(0.1M));

            //Act
            var resultado = juroDataProvider.ConsultarApiTaxaJuro();
            resultado.Wait();

            //Assert
            Assert.True(resultado.Result.IsSuccess);
            Assert.Equal(0.1M, resultado.Result.Value.Valor);
        }

        [Fact]
        public void ConsultarApiTaxaJuro_FluxoInsucesso_ResultFailure()
        {
            //Arrange
            apiBuscarTaxaJuroAdapterMock.Setup(f => f.BuscarTaxaJuro())
                .ReturnsAsync(Result.Failure<decimal>("Teste Erro"));

            //Act
            var resultado = juroDataProvider.ConsultarApiTaxaJuro();
            resultado.Wait();

            //Assert
            Assert.True(resultado.Result.IsFailure);
            Assert.Equal("Teste Erro", resultado.Result.Error);
        }

        [Fact]
        public void ConsultarApiTaxaJuro_FluxoTaxaInvalida_ResultFailure()
        {
            //Arrange
            apiBuscarTaxaJuroAdapterMock.Setup(f => f.BuscarTaxaJuro())
                .ReturnsAsync(Result.Success<decimal>(-1M));

            //Act
            var resultado = juroDataProvider.ConsultarApiTaxaJuro();
            resultado.Wait();

            //Assert
            Assert.True(resultado.Result.IsFailure);
            Assert.NotEmpty(resultado.Result.Error);
        }
    }
}
