using System;

namespace Domain.Dtos
{
    [Serializable]
    public class CalculoDtoResponse
    {
        public decimal ValorFinal { get; set; }
        public string Mensagem { get; set; }
    }

}
