using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UsoEstudiante : MonoBehaviour
{
    [Header("Datos del Estudiante")]
    public string nombreEstudiante = "";
    public string mailEstudiante = "";
    public string direccionEstudiante = "";
    public string codigoEstudiante = "";
    public string carreraEstudiante = "";

    [Header("Referencias UI")]
    public TMP_InputField inputNombre;
    public TMP_InputField inputMail;
    public TMP_InputField inputDireccion;
    public TMP_InputField inputCodigo;
    public TMP_InputField inputCarrera;
    public Button btnAgregar;

    [FormerlySerializedAs("ListaE")] [Header("Lista de Estudiantes")]
    public List<Estudiante> listaE = new List<Estudiante>();

    void Start()
    {
        // Crear estudiantes genéricos
        Estudiante e1 = new Estudiante("Juan", "juan@mail.com", "Calle 1", "E001", "Ingeniería");
        Estudiante e2 = new Estudiante("Ana", "ana@mail.com", "Calle 2", "E002", "Medicina");
        Estudiante e3 = new Estudiante("Luis", "luis@mail.com", "Calle 3", "E003", "Arquitectura");

        listaE.Add(e1);
        listaE.Add(e2);
        listaE.Add(e3);

        if (btnAgregar != null)
            btnAgregar.onClick.AddListener(AgregarEstudianteFromUI);

        foreach (Estudiante e in listaE)
        {
            Debug.Log($"Nombre: {e.NameP}, Mail: {e.MailP}, Dirección: {e.DirP}, Código: {e.CodeEProp}, Carrera: {e.NameCarreraEProp}");
        }
    }

    public void AgregarEstudianteFromUI()
    {
        if (inputNombre != null && inputCodigo != null &&
            !string.IsNullOrEmpty(inputNombre.text) && !string.IsNullOrEmpty(inputCodigo.text))
        {
            Estudiante nuevoEstudiante = new Estudiante(
                inputNombre.text,
                string.IsNullOrEmpty(inputMail.text) ? "" : inputMail.text,
                string.IsNullOrEmpty(inputDireccion.text) ? "" : inputDireccion.text,
                inputCodigo.text,
                inputCarrera.text
            );

            listaE.Add(nuevoEstudiante);
            Debug.Log($"Estudiante agregado: {inputNombre.text}");

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
    public void GuardarJson()
    {
        Utilidades.GuardarEstudiantesJson(listaE);
    }

    [ContextMenu("Cargar Estudiantes desde JSON")]
    public void CargarJson()
    {
        listaE = Utilidades.CargarEstudiantesJson();
        Debug.Log($"Cargados {listaE.Count} estudiantes desde JSON");
    }
}