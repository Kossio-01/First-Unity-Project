using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PackagesPunto2D;

public class UsoPunto2D : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField inputX;
    public TMP_InputField inputY;
    public Button btnAgregar;

    [Header("Lista de Puntos")]
    public List<Punto2D> ListaPuntos = new List<Punto2D>();

    void Start()
    {
        // Crear puntos de prueba
        Punto2D p1 = new Punto2D(1.5f, 2.7f);
        Punto2D p2 = new Punto2D(-3.2f, 4.8f);
        Punto2D p3 = new Punto2D(0.0f, -1.5f);

        ListaPuntos.Add(p1);
        ListaPuntos.Add(p2);
        ListaPuntos.Add(p3);

        // Configurar botón
        if (btnAgregar != null)
            btnAgregar.onClick.AddListener(AgregarPuntoFromUI);

        foreach (Punto2D p in ListaPuntos)
        {
            Debug.Log($"Punto: X={p.X}, Y={p.Y}");
        }
    }

    public void AgregarPuntoFromUI()
    {
        if (inputX != null && inputY != null && 
            !string.IsNullOrEmpty(inputX.text) && !string.IsNullOrEmpty(inputY.text))
        {
            float x = float.Parse(inputX.text);
            float y = float.Parse(inputY.text);
            
            Punto2D nuevoPunto = new Punto2D(x, y);
            ListaPuntos.Add(nuevoPunto);
            Debug.Log($"Punto agregado: ({x}, {y})");
            
            // Limpiar campos
            inputX.text = "";
            inputY.text = "";
        }
    }

    [ContextMenu("Guardar Puntos en JSON")]
    public void GuardarJSON()
    {
        Utilidades.GuardarPuntosJSON(ListaPuntos);
    }

    [ContextMenu("Cargar Puntos desde JSON")]
    public void CargarJSON()
    {
        ListaPuntos = Utilidades.CargarPuntosJSON();
        Debug.Log($"Cargados {ListaPuntos.Count} puntos desde JSON");
    }

    void Update()
    {
        
    }
}
