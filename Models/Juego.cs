using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class Juego
{
    public static string username { get; set; }
    public static int PuntajeActual { get; set; }
    public static int CantidadPreguntasCorrectas { get; set; }
    public static int ContadorNroPreguntaActual { get; set; }
    public static Preguntas PreguntaActual { get; set; }
    public static List<Preguntas> ListaPregunta { get; set; } = new List<Preguntas>();
    public static List<Respuestas> ListaRespuesta { get; set; } = new List<Respuestas>();

    private static void InicializarJuego()
    {
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPregunta = new List<Preguntas>();
        ListaRespuesta = new List<Respuestas>();

    }

    public List<Categoria> ObtenerCategorias()
    {
        List<Categoria> categoria = BD.ObtenerCategorias();
        return categoria;
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> dificultad = BD.ObtenerDificultades();
        return dificultad;
    }

    public static void CargarPartida(string Username, int dificultad, int categoria)
    {
        InicializarJuego();
        Username = username;
        ListaPregunta = BD.ObtenerPreguntas(dificultad, categoria);
        if (ListaPregunta != null && ListaPregunta.Count > 0)
        {
            PreguntaActual = ListaPregunta[0];
        }
    }

    public static Preguntas ObtenerProximaPregunta()
    {
        if (ContadorNroPreguntaActual < ListaPregunta.Count && ListaPregunta != null)
        {
            PreguntaActual = ListaPregunta[ContadorNroPreguntaActual];
            ContadorNroPreguntaActual++;
            return PreguntaActual;
        }
        else
        {
            return null;
        }
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        ListaRespuesta = BD.ObtenerRespuestas(idPregunta);
        return ListaRespuesta;
    }

    public static bool VerificarRespuesta(int idRespuesta)
    {
        bool Correcta = false;
        foreach (Respuestas respuesta in ListaRespuesta)
        {
            if (respuesta.IdRespuesta == idRespuesta && respuesta.Correcta == true)
            {
                Correcta = true;
                CantidadPreguntasCorrectas++;
                PuntajeActual++;
            }
        }
        return Correcta;
    }
}
