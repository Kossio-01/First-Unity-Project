using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PackagePersona;
public class UsarPersona : MonoBehaviour
{

    List<Estudiante> ListaE=new List<Estudiante>();
    void Start()
    {
        Estudiante e1 = new Estudiante("12345", "Ingeniería de Software", "David", "CoreeoQgenerico");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
