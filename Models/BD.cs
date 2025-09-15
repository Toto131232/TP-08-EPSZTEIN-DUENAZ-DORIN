using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private static string _connectionString = @"Server=localhost;Database=TP08;Integrated Security=True;TrustServerCertificate=True;";

   public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
    public static void ObtenerDificultades()
    {
    using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Nombre FROM Dificultad";
            var dificultad = connection.Query<Dificultad>(query).ToList();
            
        }
    }

    public static void ObtenerPreguntas(int dificultad, int categoria)
    {
        using (SqlConnection connection = ObtenerConexion())
        {
            var query = "SELECT Enunciado FROM Preguntas WHERE DiIdDificultad=@dificultad AND ";
            var pregunta = connection.Query<Preguntas>(query).ToList();
            
        }
    }

    public static void ObtenerRespuestas(int IdPregunta)
    {
using (SqlConnection connection = ObtenerConexion())
        {
            var query = "";
            var Respuesta = connection.Query<Respuestas>(query).ToList();
            
        }
    }
}
