namespace ProdApi.Services
{
    public class RelevanciaService
    {
        private readonly HashSet<string> _lista1;
        private readonly HashSet<string> _lista2;

        public RelevanciaService()
        {
            _lista1 = CarregarLista("lista_relevancia_1.txt");
            _lista2 = CarregarLista("lista_relevancia_2.txt");
        }

        private HashSet<string> CarregarLista(string nArquivo)
        {
            var caminho = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                nArquivo);

            return File.ReadAllLines(caminho)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .ToHashSet();
        }
        public int ObterPrioridade(string cdProduto)
        {
            if (_lista1.Contains(cdProduto))
                return 1;

            if (_lista2.Contains(cdProduto))
                return 2;

            return 3;
        }
    }
}
