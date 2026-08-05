using System.Data;

namespace ProdApi.Models
{
    public class LoginResp
    {
        public bool Sucesso { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string Mensagem { get; set; } = string.Empty;

        public DateTime ExpiraEm { get; set; }
    }
}
