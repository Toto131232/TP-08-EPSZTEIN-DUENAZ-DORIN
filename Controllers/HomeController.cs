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
        var juego = new Juego();
        juego.CargarPartida(username, dificultad, categoria);
        Juego.GuardarEnSession(HttpContext.Session, juego);
        return RedirectToAction("Jugar");
    }
    public IActionResult ConfigurarJuego()
    {
        var juego = Juego.LeerDesdeSession(HttpContext.Session) ?? new Juego();
        ViewBag.Categorias = juego.ObtenerCategorias();
        ViewBag.Dificultades = juego.ObtenerDificultades();
        return View();
    }
    public IActionResult Jugar()
    {
        var juego = Juego.LeerDesdeSession(HttpContext.Session);
        if (juego == null || !juego.HayPreguntasDisponibles())
        {
            return View("Fin");
        }

        var pregunta = juego.GetPreguntaActual();
        ViewBag.Username = juego.Username;
        ViewBag.Puntaje = juego.GetPuntajeActual();
        ViewBag.NroPregunta = juego.GetNroPreguntaActual() + 1;
        ViewBag.Pregunta = pregunta;
        ViewBag.Respuestas = juego.GetRespuestasActuales() ?? juego.ObtenerProximasRespuestas(pregunta.Id);
        Juego.GuardarEnSession(HttpContext.Session, juego);

        return View("Juego");
    }

     [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        var juego = Juego.LeerDesdeSession(HttpContext.Session);
        if (juego == null) return RedirectToAction("ConfigurarJuego");

        bool correcta = juego.VerificarRespuesta(idRespuesta);

        Juego.GuardarEnSession(HttpContext.Session, juego);

        ViewBag.Correcta = correcta;
     
        var respuestas = BD.ObtenerRespuestas(idPregunta);
        var correctaObj = respuestas.FirstOrDefault(r => r.EsCorrecta);
        ViewBag.RespuestaCorrecta = correctaObj;

        return View("Respuesta");
    }
}
