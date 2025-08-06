using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PackagesPesona;

public class UsoEstudiante : MonoBehaviour
{
    [Header("Datos del Estudiante")]
    public string nombreEstudiante = "";
    public int mailEstudiante = 0;
    public int direccionEstudiante = 0;
    public string codigoEstudiante = "";
    public string carreraEstudiante = "";

    [Header("Referencias UI")]
    public TMP_InputField inputNombre;
    public TMP_InputField inputMail;
    public TMP_InputField inputDireccion;
    public TMP_InputField inputCodigo;
    public TMP_InputField inputCarrera;
    public Button btnAgregar;

    [Header("Lista de Estudiantes")]
    public List<Estudiante> ListaE = new List<Estudiante>();
    
    void Start()
    {
        // Crear estudiantes genericos
        Estudiante e1 = new Estudiante("Juan", "123456789", "20", "E001", "Ingeniería");
        Estudiante e2 = new Estudiante("Ana", "987654321", "21", "E002", "Medicina");
        Estudiante e3 = new Estudiante("Luis", "456789123", "22", "E003", "Arquitectura");

        ListaE.Add(e1);
        ListaE.Add(e2);
        ListaE.Add(e3);

        //  botón
        if (btnAgregar != null)
            btnAgregar.onClick.AddListener(AgregarEstudianteFromUI);

        foreach (Estudiante e in ListaE)
        {
            Debug.Log($"Nombre: {e.NameP}, Mail: {e.MailP}, Dirección: {e.DirP}, Código: {e.CodeEProp}, Carrera: {e.NameCarreraEProp}");
        }
    }

    public void AgregarEstudianteFromUI()
    {
        if (inputNombre != null && inputCodigo != null && 
            !string.IsNullOrEmpty(inputNombre.text) && !string.IsNullOrEmpty(inputCodigo.text))
        {
            // Validar 
            if (!string.IsNullOrEmpty(inputMail.text))
            {
                if (!int.TryParse(inputMail.text, out _))
                {
                    Debug.LogError("Mail debe ser un número válido");
                    return;
                }
            }
             
            if (!string.IsNullOrEmpty(inputDireccion.text))
            {
                if (!int.TryParse(inputDireccion.text, out _))
                {
                    Debug.LogError("Dirección debe ser un número válido");
                    return;
                }
            }
            
            Estudiante nuevoEstudiante = new Estudiante(
                inputNombre.text, 
                string.IsNullOrEmpty(inputMail.text) ? "0" : inputMail.text,
                string.IsNullOrEmpty(inputDireccion.text) ? "0" : inputDireccion.text,
                inputCodigo.text, 
                inputCarrera.text
            );
            
            ListaE.Add(nuevoEstudiante);
            Debug.Log($"Estudiante agregado: {inputNombre.text}");
            
            // Crear Clear
            inputNombre.text = "";
            inputMail.text = "";
            inputDireccion.text = "";
            inputCodigo.text = "";
            inputCarrera.text = "";
        }
        else
        {
            Debug.LogError("Nombre y Código son campos obligatorios");
        }
    }

    [ContextMenu("Guardar Estudiantes en JSON")]
    public void GuardarJSON()
    {
        Utilidades.GuardarEstudiantesJSON(ListaE);
    }

    [ContextMenu("Cargar Estudiantes desde JSON")]
    public void CargarJSON()
    {
        ListaE = Utilidades.CargarEstudiantesJSON();
        Debug.Log($"Cargados {ListaE.Count} estudiantes desde JSON");
    }

    void Update()
    {

    }
}