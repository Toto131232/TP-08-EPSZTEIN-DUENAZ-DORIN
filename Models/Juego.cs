using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class Juego
{
    public string username{get;set;}
    public  int PuntajeActual{get;set;}
    public int CantidadPreguntasCorrectas{get;set;}
    public int ContadorNroPreguntaActual;
    public Preguntas PreguntaActual;
    public List<Preguntas> ListaPregunta;
    public List<Respuestas> ListaRespuesta;

    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }

private static void InicializarJuego()
{
   username="";
   PuntajeActual=0;
   CantidadPreguntasCorrectas=0;
   ContadorNroPreguntaActual=0;
   ListaPregunta=null;
   ListaPreguntas=null;
   ListaRespuestas=null;

}

public List<Categoria> ObtenerCategorias()
{
    List<Categoria> categorias = new List<Categoria>();
    using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Nmbre FROM Categorias";
            categorias = connection.Query<CategoriaD>(query).ToList();
        }
        return categorias;
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

public Respuestas VerificarRespuesta(int idRespuesta)
{
    bool respuestas;
    using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Correcta Respuestas WHERE IdRespuessta=@idRespuesta";
            respuestas = connection.QueryFirstOrDefault<Respuestas>(query, idRespuesta=idRespuesta).ToList();
        }
    return respuestas;
        
}
}


