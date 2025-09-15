using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class Preguntas
{
    public int IdPregunta{get;set;}
    public int IdCategoria{get;set;}
    public int IdDificultad{get;set;}
    public string Enunciado{get;set;}
}