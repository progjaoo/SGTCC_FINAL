namespace SistemaGestaoTCC.Core.Exceptions
{
    public class DataEntregaInvalidaException : Exception
    {
        public DataEntregaInvalidaException() : base("A data de entrega não pode ser anterior à data de criação.")
        {
        }

        public DataEntregaInvalidaException(string message) : base(message)
        {
        }

        public DataEntregaInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
