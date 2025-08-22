using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PilaTextos : MonoBehaviour
{
    private Stack<string> pila = new Stack<string>();
    public TMP_Text textoPila;
    public TMP_Text textoAccion;
    public TMP_InputField inputField;

    public void Push(string cadena)
    {
        pila.Push(cadena);
        MostrarPila();
        textoAccion.text = $"Push: {cadena}";
    }

    public void PushFromInput()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            Push(inputField.text);
            inputField.text = "";
        }
    }

    public void Pop()
    {
        if (pila.Count > 0)
        {
            string popped = pila.Pop();
            MostrarPila();
            textoAccion.text = $"Pop: {popped}";
        }
        else
        {
            textoAccion.text = "No hay elementos en la pila";
        }
    }

    public void ClearStack()
    {
        pila.Clear();
        MostrarPila();
        textoAccion.text = "Espacios Eliminados";
    }

    public void Peek()
    {
        if (pila.Count > 0)
            textoAccion.text = $"EL peak es:  {pila.Peek()}";
        else
            textoAccion.text = "No hay elementos en la pila";
    }

    void MostrarPila()
    {
        if (pila.Count == 0)
        {
            textoPila.text = "Stack is empty";
            return;
        }

        textoPila.text = "Stack (top ↓):\n";
        foreach (var item in pila)
        {
            textoPila.text += $"[ {item} ]\n↓\n";
        }
        textoPila.text = textoPila.text.TrimEnd('\n', '↓'); // Remove last arrow
    }
}