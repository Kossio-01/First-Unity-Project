using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PackagesPesona;

public class UsoEstudiante : MonoBehaviour
{
    List<Estudiante> ListaE = new List<Estudiante>();

    void Start()
    {
        Estudiante e1 = new Estudiante("Juan", 123456789, 20, "E001", "Ingeniería");
        Estudiante e2 = new Estudiante("Ana", 987654321, 21, "E002", "Medicina");
        Estudiante e3 = new Estudiante("Luis", 456789123, 22, "E003", "Arquitectura");

        ListaE.Add(e1);
        ListaE.Add(e2);
        ListaE.Add(e3);

        foreach (Estudiante e in ListaE)
        {
            Debug.Log($"Nombre: {e.NameP}, Mail: {e.MailP}, Dirección: {e.DirP}, Código: {e.CodeEProp}, Carrera: {e.NameCarreraEProp}");
        }
    }

    void Update()
    {

    }
}