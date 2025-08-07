using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class EstudiantesData
{
    public List<Estudiante> estudiantes;
}

[System.Serializable]
public class PuntosData
{
    public List<Punto2D> puntos;
}

public static class Utilidades
{
    public static void GuardarEstudiantesJson(List<Estudiante> listaEstudiantes)
    {
        EstudiantesData data = new EstudiantesData();
        data.estudiantes = listaEstudiantes;
        
        string json = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "estudiantes.json");
        
        File.WriteAllText(path, json);
        Debug.Log($"Estudiantes guardados en: {path}");
        Debug.Log($"JSON generado:\n{json}");
    }

    public static void GuardarPuntosJson(List<Punto2D> listaPuntos)
    {
        PuntosData data = new PuntosData();
        data.puntos = listaPuntos;
        
        string json = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "puntos.json");
        
        File.WriteAllText(path, json);
        Debug.Log($"Puntos guardados en: {path}");
        Debug.Log($"JSON generado:\n{json}");
    }

    public static List<Estudiante> CargarEstudiantesJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "estudiantes.json");
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            EstudiantesData data = JsonUtility.FromJson<EstudiantesData>(json);
            return data.estudiantes;
        }
        
        Debug.LogWarning("No se encontró el archivo de estudiantes");
        return new List<Estudiante>();
    }

    public static List<Punto2D> CargarPuntosJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "puntos.json");
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PuntosData data = JsonUtility.FromJson<PuntosData>(json);
            return data.puntos;
        }
        
        Debug.LogWarning("No se encontró el archivo de puntos");
        return new List<Punto2D>();
    }
}
