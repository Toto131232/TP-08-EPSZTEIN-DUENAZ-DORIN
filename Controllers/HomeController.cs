using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using Newtonsoft.Json;


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
        ViewBag.Username = HttpContext.Session.GetString("Username"); ;
        Console.WriteLine(ViewBag.Username);
        ViewBag.PuntajeActual = Juego.PuntajeActual;
        ViewBag.Pregunta = preguntas;
        ViewBag.Respuestas = respuestas;
        ViewBag.ContadorNroPreguntaActual = Juego.ContadorNroPreguntaActual;
        ViewBag.Pregutashechas = Juego.ContadorNroPreguntaActual - 1;
        ViewBag.PreguntasTotales = Juego.ListaPregunta.Count;
        return View("Jugar");
    }


    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool EsCorrecta = Juego.VerificarRespuesta(idRespuesta);
        ViewBag.EsCorrecta = EsCorrecta;
        ViewBag.idRespuesta = idPregunta;
        if(!EsCorrecta)
        {
            foreach (Respuestas resp in Juego.ListaRespuesta)
            {
                if (resp.Correcta)
                {
                    ViewBag.RespuestaCorrecta = resp.Contenido;
                }
            }
        }

        return View("Respuesta");
    }


    public IActionResult Fin()
    {
        ViewBag.PreguntasTotales = Juego.ListaPregunta.Count;
        ViewBag.Username = HttpContext.Session.GetString("Username"); ;
        ViewBag.PuntajeFinal = Juego.PuntajeActual;
        ViewBag.Porcentaje = ViewBag.PuntajeFinal * 100 / ViewBag.PreguntasTotales;
        return View();
    }
    public IActionResult Respuesta()
    {
        return View();
    }
}
