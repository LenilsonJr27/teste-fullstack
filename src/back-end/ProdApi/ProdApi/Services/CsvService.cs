using ProdApi.Models;

namespace ProdApi.Services
{
    public class CsvService
    {
        private readonly List<Produto> _produtos;
        public CsvService()
        {
            _produtos = CarregarProdutos();
        }

        public List<Produto> ObterProdutos()
        {
            return _produtos;
        }

        private List<Produto> CarregarProdutos()
        {
            var produtos = new List<Produto>();

            var caminho = Path.Combine(AppContext.BaseDirectory,
                "Data",
                "sample_db.csv");

            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas.Skip(1))
            {
                var campos = linha.Split(';');

                produtos.Add(new Produto
                {
                    Id = campos[0].Trim(),
                    CodigoProduto = campos[1].Trim(),
                    DescricaoProduto = campos[2].Trim(),
                    CodigoCor = campos[3].Trim(),
                    DescricaoCor = campos[4].Trim(),
                    CodigoTamanho = campos[5].Trim(),
                    DescricaoTamanho = campos[6].Trim()
                });
            }

            return produtos;
        }
    }
}
//O CsvService vai ler, converter e guardar na memória