using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost;Database=TP -08;Integrated Security=True;TrustServerCertificate=True;";

   public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
    public static List<Dificultad> ObtenerDificultades()
    {
    using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Nombre FROM Dificultad";
            var dificultad = connection.Query<Dificultad>(query).ToList();
            return dificultad;
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Enunciado FROM Preguntas WHERE DiIdDificultad=@dificultad AND ";
            var pregunta = connection.Query<Preguntas>(query).ToList();
            return pregunta;
        }
    }

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        List<Respuestas> respuestas = new List<Respuestas>();
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT * FEOM Respuestas WHERE IdPregunta=@idPregunta";
            respuestas = connection.Query<Respuestas>(query, new {IdPregunta=idPregunta}).ToList();
             return respuestas;
            
        }
       
    }

   public static List<Categoria> ObtenerCategorias()
{
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Nombre FROM Categoria";
            var categoria = connection.Query<Categoria>(query).ToList();
            return categoria; 
        }
}
}
