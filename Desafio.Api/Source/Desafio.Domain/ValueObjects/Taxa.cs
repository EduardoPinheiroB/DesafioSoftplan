using Flunt.Notifications;

namespace Desafio.Domain.ValueObjects
{
    public class Taxa : Notifiable<Notification>
    {
        public decimal Valor { get; private set; }

        public Taxa(decimal valor)
        {
            Valor = valor;

            if (Valor <= 0)
                AddNotification("Taxa", "Taxa tem que ser maior que zero");
        }
    }
}
