using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost;Database=TP-08;Integrated Security=True;TrustServerCertificate=True;";

   public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
    public static List<Dificultad> ObtenerDificultades()
    {
    using (SqlConnection connection = ObtenerConexion())
        {
            string query = "SELECT Nombre FROM Dificultad";
            List<Dificultad> dificultad = connection.Query<Dificultad>(query).ToList();
            return dificultad;
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
{
    List<Preguntas> preguntas = new List<Preguntas>();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = @"SELECT * FROM Preguntas WHERE (@TDificultad = -1 OR IDDificultad = @TDificultad) AND (@TCategoria   = -1 OR IDCategoria  = @TCategoria)";
        preguntas = connection.Query<Preguntas>(query, new { TDificultad = dificultad, TCategoria = categoria }).ToList();
    }
    return preguntas;
}

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            string query = "SELECT * FEOM Respuestas WHERE IdPregunta=@idPregunta";
            List<Respuestas> respuestas = connection.Query<Respuestas>(query, new { IdPregunta = idPregunta }).ToList();
             return respuestas;
            
        }
       
    }

   public static List<Categoria> ObtenerCategorias()
{
        using (SqlConnection connection = ObtenerConexion())
        {
            string query = "SELECT * FROM Categorias";
            List<Categoria> categoria = connection.Query<Categoria>(query).ToList();
            return categoria; 
        }
}
}
