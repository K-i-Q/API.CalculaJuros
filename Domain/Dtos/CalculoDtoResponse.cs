using System;

namespace Domain.Dtos
{
    [Serializable]
    public class CalculoDtoResponse
    {
        public decimal TaxaJuros { get; set; }
        public string Mensagem { get; set; }
    }

}
