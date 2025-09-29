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
        Juego.CargarPartida(username, dificultad, categoria);
        HttpContext.Session.SetString("Username", username);
        
        return RedirectToAction("Jugar");
    }
    public IActionResult ConfigurarJuego()
    {
        ViewBag.categorias = BD.ObtenerCategorias();
        ViewBag.dificultades = BD.ObtenerDificultades();
        return View();
    }
    public IActionResult Jugar()
    {
        Preguntas preguntas = Juego.ObtenerProximaPregunta();
        
        if (preguntas == null)
        {
            return RedirectToAction("Fin");
        }
        
        List<Respuestas> respuestas = Juego.ObtenerProximasRespuestas(preguntas.IdPregunta);
        Juego.ListaRespuesta = respuestas;
        
        ViewBag.username = Juego.username;
        ViewBag.puntajeactual = Juego.PuntajeActual;
        ViewBag.pregunta = preguntas;
        ViewBag.respuestas = respuestas;
        ViewBag.contadornropreguntaactual = Juego.ContadorNroPreguntaActual;

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
