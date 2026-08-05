using Microsoft.AspNetCore.Mvc;
using ProdApi.Models;
using ProdApi.Services;

namespace ProdApi.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var resultado = _loginService.Login(request);

        if (!resultado.Sucesso)
            return Unauthorized(resultado);

        return Ok(resultado);
    }
}