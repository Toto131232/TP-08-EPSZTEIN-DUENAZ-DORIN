using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class Juego
{
    public string username{get;set;}
    public  int PuntajeActual{get;set;}
    public int CantidadPreguntasCorrectas{get;set;}
    public int ContadorNroPreguntaActual{get;set;}
    public Preguntas PreguntaActual{get;set;}
    public List<Preguntas> ListaPregunta{get;set;}
    public List<Respuestas> ListaRespuesta{get;set;}
}
private void InicializarJuego()
{
}

public List<string> ObtenerCategorias()
{
    
}

public List<string> ObtenerDificultades()
{
    
}

public void CargarPartida(string username, int dificultad, int categoria)
{
}

public Pregunta ObtenerProximaPregunta()
{

}

public List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
{
   
}

public bool VerificarRespuesta(int idRespuesta)
{
    
}


