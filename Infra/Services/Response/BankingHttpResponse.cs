namespace Infra.Services.Response
{
    public class BankingHttpResponse
    {
        public int? StatusCodeHttp { get; set; }
        public string? CustomResponseError { get;  set; }
        public bool Sucesso
        {
            get
            {
                if (StatusCodeHttp != 200)
                {
                    return StatusCodeHttp == 201;
                }

                return true;
            }
        }
        public bool BadRequest
        {
            get
            {
                if (StatusCodeHttp == 400)
                {
                    return true;
                }

                return false;
            }
        }
        public bool NotFound
        {
            get
            {
                if (StatusCodeHttp == 404)
                {
                    return true;
                }

                return false;
            }
        }
        public bool Unprocessable
        {
            get
            {
                if (StatusCodeHttp == 422)
                {
                    return true;
                }

                return false;
            }
        }
        public bool ServicoIndisponivel => StatusCodeHttp >= 500;
    }
}
