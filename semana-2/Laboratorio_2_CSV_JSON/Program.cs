using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; 
class Program
{
    static void Main()
    {
        string rutaCsv = "estudiantes.csv";
        string rutaJson = "estudiantes.json";

        List<Estudiante> listaEstudiantes = new List<Estudiante>();

        string[] lineas = File.ReadAllLines(rutaCsv);

        for (int i = 1; i < lineas.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lineas[i])) continue;

            string[] datos = lineas[i].Split(',');

            Estudiante estudiante = new Estudiante
            {
                Id = int.Parse(datos[0].Trim()),
                Nombre = datos[1].Trim(),
                Carrera = datos[2].Trim()
            };

            listaEstudiantes.Add(estudiante);
        }

        Console.WriteLine("--- Lista de Estudiantes ---");
        foreach (var est in listaEstudiantes)
        {
            Console.WriteLine($"ID: {est.Id} | Nombre: {est.Nombre} | Carrera: {est.Carrera}");
        }

        string jsonResult = JsonSerializer.Serialize(listaEstudiantes, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(rutaJson, jsonResult);

        Console.WriteLine("\nSe ha generado estudiantes.json");
    }
}