using ProdApi.Models;

namespace ProdApi.Services
{
    public class BuscaService
    {
        private readonly CsvService _csvService;
        private readonly RelevanciaService _relevanciaService;

        public BuscaService(
            CsvService csvService,
            RelevanciaService relevanciaService)
        {
            _csvService = csvService;
            _relevanciaService = relevanciaService;
        }

        public List<Produto> Buscar(string termo, int pagina = 1)
        {
            var produtos = _csvService.ObterProdutos();

            var resultado = produtos
                .Where(p =>
                    p.DescricaoProduto.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                    p.CodigoProduto.Contains(termo))
                .OrderBy(p => _relevanciaService.ObterPrioridade(p.CodigoProduto))
                .ThenBy(p => p.DescricaoProduto)
                .Skip((pagina - 1) * 15)
                .Take(15)
                .ToList();

            return resultado;
        }
    }
}