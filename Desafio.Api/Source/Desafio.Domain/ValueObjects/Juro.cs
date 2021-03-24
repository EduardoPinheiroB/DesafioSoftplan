using System;
using System.Linq;
using DecimalMath;
using Flunt.Notifications;

namespace Desafio.Domain.ValueObjects
{
    public class Juro : Notifiable<Notification>
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

            if(valorInicial <= 0)
                AddNotification("ValorInicial", "ValorInicial tem que ser maior que zero");

            if (!Taxa.IsValid)
                AddNotification(Taxa.Notifications.First());

            if (Tempo <= 0)
                AddNotification("Tempo", "Tempo tem que ser maior que zero");

            if (Tempo > 100)
                AddNotification("Tempo", "Tempo tem que ser menor que cem");
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
