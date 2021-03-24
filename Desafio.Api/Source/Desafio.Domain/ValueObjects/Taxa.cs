namespace Desafio.Domain.ValueObjects
{
    public class Taxa
    {
        public decimal Valor { get; private set; }

        public Taxa(decimal valor)
        {
            Valor = valor;
        }
    }
}
