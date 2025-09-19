using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class Juego
{
    public string username{get;set;}
    public static  int PuntajeActual{get;set;}
    public static int CantidadPreguntasCorrectas{get;set;}
    public static int ContadorNroPreguntaActual{get;set;}
    public static Preguntas PreguntaActual{get;set;}
    public static List<Preguntas> ListaPregunta{get;set;}=new List<Preguntas>();
    public static List<Respuestas> ListaRespuesta{get;set;}=new List<Respuestas>();

private static void InicializarJuego()
    {
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        ListaPregunta = null;
        ListaPregunta = null;
        ListaRespuesta = null;

    }

public List<Categoria> ObtenerCategorias()
{
        List<Categoria> categoria=BD.ObtenerCategorias();
        return categoria;
}

 public static List<Dificultad> ObtenerDificultades()
{
    List<Dificultad> dificultad=BD.ObtenerDificultades();
    return dificultad;
}

    public void CargarPartida(string username, int dificultad, int categoria)
    {
        InicializarJuego();
        this.username = username;
        ListaPregunta = BD.ObtenerPreguntas(dificultad, categoria);
        if(ListaPregunta.Count>0)
        {
            PuntajeActual=ListaPregunta[0];
        }
}

public Preguntas ObtenerProximaPregunta()
{
    if(ContadorNroPreguntaActual<ListaPregunta.Count&&ListaPregunta!=null)
    {
        PreguntaActual=ListaPregunta[ContadorNroPreguntaActual];
        ContadorNroPreguntaActual++;
        return PreguntaActual;
    }
    else
    {
        return null;
    }
}

    public List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        ListaRespuesta = BD.ObtenerRespuestas(idPregunta);
        return ListaRespuesta;
    }

    public bool VerificarRespuesta(int idRespuesta)
    {
        bool Correcta = false;
        foreach (Respuestas respuesta in ListaRespuesta)
        {
            if (respuesta.IdRespuesta == idRespuesta && respuesta.Correcta)
            {
                Correcta = true;
                CantidadPreguntasCorrectas++;
                PuntajeActual += 1;
            }
        }
        return Correcta;
    }
}