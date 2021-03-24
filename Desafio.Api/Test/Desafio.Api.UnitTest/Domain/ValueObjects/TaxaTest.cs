using Desafio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Desafio.Api.UnitTest.Domain.ValueObjects
{
    public class TaxaTest
    {
        [Theory]
        [InlineData(-1)]
        public void New_TaxaComNotification_Taxa(decimal valor)
        {
            //Arrange

            //Act
            var taxa = new Taxa(valor);

            //Assert
            Assert.False(taxa.IsValid);
            Assert.NotNull(taxa.Notifications);
            Assert.True(taxa.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(0.5)]
        public void New_TaxaSemNotification_Taxa(decimal valor)
        {
            //Arrange

            //Act
            var taxa = new Taxa(valor);

            //Assert
            Assert.True(taxa.IsValid);
            Assert.True(taxa.Notifications.Count == 0);
            Assert.Equal(0.5M, taxa.Valor);
        }
    }
}
