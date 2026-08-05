using Microsoft.AspNetCore.Mvc;
using ProdApi.Services;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly BuscaService _buscaService;

    public ProdutosController(BuscaService buscaService)
    {
        _buscaService = buscaService;
    }

    [HttpGet]
    public IActionResult Buscar([FromQuery] string busca)
    {
        var result = _buscaService.Buscar(busca);

        return Ok(result);
    }
}