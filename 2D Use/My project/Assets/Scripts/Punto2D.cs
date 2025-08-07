using UnityEngine;

[System.Serializable]
public class Punto2D
{
    [SerializeField] private float x;
    [SerializeField] private float y;

    public Punto2D() { }

    public Punto2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
}