using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=DESKTOP-INA4G9O\SQLEXPRESS;Database=TP-08;Integrated Security=True;TrustServerCertificate=True;";
    public static List<Dificultad> ObtenerDificultades()
    {
    using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Dificultad";
            List<Dificultad> dificultad = connection.Query<Dificultad>(query).ToList();
            return dificultad;
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = @"SELECT * FROM Preguntas WHERE (@pdificultad = -1 OR IdDificultad = @pdificultad) AND (@pcategoria = -1 OR IdCategoria = @pcategoria)";
        return connection.Query<Preguntas>(query, new { pdificultad = dificultad, pcategoria = categoria }).ToList();
    }
}

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Respuestas WHERE IdPregunta=@idPregunta";
            List<Respuestas> respuestas = connection.Query<Respuestas>(query, new { IdPregunta = idPregunta }).ToList();
             return respuestas;
            
        }
       
    }

   public static List<Categoria> ObtenerCategorias()
{
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Categorias";
            List<Categoria> categoria = connection.Query<Categoria>(query).ToList();
            return categoria; 
        }
}
}
