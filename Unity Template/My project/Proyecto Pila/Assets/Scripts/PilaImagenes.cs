using System.Collections.Generic;
using UnityEngine;

public class PilaImagenes : MonoBehaviour
{
    public GameObject imagenPrefab; // Asigna un prefab de imagen en el inspector
    private Stack<GameObject> pilaImagenes = new Stack<GameObject>();
    private Vector3 posicionInicial = new Vector3(0, 0, 0);

    public void ApilarImagen()
    {
        Vector3 nuevaPos = posicionInicial + Vector3.up * pilaImagenes.Count * 1.5f;
        GameObject nuevaImagen = Instantiate(imagenPrefab, nuevaPos, Quaternion.identity);
        pilaImagenes.Push(nuevaImagen);
    }

    public void DesapilarImagen()
    {
        if (pilaImagenes.Count > 0)
        {
            GameObject img = pilaImagenes.Pop();
            Destroy(img);
        }
    }
}