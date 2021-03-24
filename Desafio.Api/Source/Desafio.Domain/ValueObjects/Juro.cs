using System;
using DecimalMath;

namespace Desafio.Domain.ValueObjects
{
    public class Juro
    {
        public Taxa Taxa { get; private set; }
        public int Tempo { get; private set; }
        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal { get; private set; }

        private Juro() { }

        public Juro(decimal taxa, int tempo, decimal valorInicial)
        {
            Taxa = new Taxa(taxa);
            Tempo = tempo;
            ValorInicial = valorInicial;
        }

        public Juro BuscarTaxaJuro()
        {
            return new Juro { Taxa = new Taxa(0.1M) };
        }

        public Juro CalcularTaxaJuros()
        {
            var resultado = ValorInicial * (DecimalEx.Pow(1 + Taxa.Valor, Tempo));
            var arrendondamento = Math.Round(resultado, 2);
            var trunk = Math.Truncate(100 * arrendondamento) / 100;

            ValorFinal = trunk;
            return this;
        }
    }
}
