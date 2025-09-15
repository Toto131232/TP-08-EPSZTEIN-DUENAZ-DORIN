using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {

    }
    public IActionResult Comenzar(string username, int dificultad, int categoria){

    }
    public IActionResult Jugar()
    {

    }

    [HttpPost] 
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {

    } 
}
