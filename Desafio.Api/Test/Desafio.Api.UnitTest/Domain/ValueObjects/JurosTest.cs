using Desafio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Api.UnitTest.Domain.ValueObjects
{
    public class JurosTest
    {
        [Theory]
        [InlineData(-1, 2, 1000)]
        [InlineData(0.01, -1, 1000)]
        [InlineData(0.01, 2, -1)]
        public void New_JuroComNotification_Juro(decimal taxa, int tempo, decimal valorInicial)
        {
            //Arrange

            //Act
            var juro = new Juro(taxa, tempo, valorInicial);

            //Assert
            Assert.False(juro.IsValid);
            Assert.NotNull(juro.Notifications);
            Assert.True(juro.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(0.01, 2, 1000)]
        public void CalcularTaxaJuros_JuroSemNotification_Juro(decimal taxa, int tempo, decimal valorInicial)
        {
            //Arrange

            //Act
            var juro = new Juro(taxa, tempo, valorInicial);

            juro.CalcularTaxaJuros();

            //Assert
            Assert.True(juro.IsValid);
            Assert.True(juro.Notifications.Count == 0);
            Assert.Equal(0.01M, juro.Taxa.Valor);
            Assert.Equal(2, juro.Tempo);
            Assert.Equal(1000, juro.ValorInicial);
            Assert.Equal(1020.1M, juro.ValorFinal);
        }
    }
}
