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
    [HttpGet]
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }
    public IActionResult Jugar()
    {
        Juego juego = Juego.ObtenerProximaPregunta();
        if (juego == null)
        {
            return View("Fin");
        }

        ViewBag.respuestas=Juego.ObtenerProximasRespuestas();
        ViewBag.pregunta=juego;


        return View("Juego");
    }

     [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool EsCorrecta=Juego.VerificarRespuesta(idRespuesta);
        ViewBag.EsCorrecta=EsCorrecta;
        return View("Respuesta");

    }
}
