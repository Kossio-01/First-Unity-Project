using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Estudiante : Persona
{
    [FormerlySerializedAs("CodeE")] [SerializeField] private string codeE;
    [SerializeField] private string nameCarreraE;

    public Estudiante() { }

    public Estudiante(string codeE, string nameCarreraE)
    {
        this.codeE = codeE;
        this.nameCarreraE = nameCarreraE;
    }

    public Estudiante(string nameP, string mailP, string dirP) : base(nameP, mailP, dirP)
    {
    }

    public Estudiante(string nameP, string mailP, string dirP, string codeE, string nameCarreraE) 
        : base(nameP, mailP, dirP)
    {
        this.codeE = codeE;
        this.nameCarreraE = nameCarreraE;
    }

    public string CodeEProp { get => codeE; set => codeE = value; }
    public string NameCarreraEProp { get => nameCarreraE; set => nameCarreraE = value; }
}