using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PackagesPesona
{
    [System.Serializable]
    public class Estudiante : Persona
    {
        private string CodeE;
        private string nameCarreraE;

        public Estudiante() { }

        public Estudiante(string codeE, string nameCarreraE)
        {
            this.CodeE = codeE;
            this.nameCarreraE = nameCarreraE;
        }

        public Estudiante(string nameP, int mailP, int dirP) : base(nameP, mailP, dirP)
        {
        }

        public Estudiante(string nameP, int mailP, int dirP, string codeE, string nameCarreraE) 
            : base(nameP, mailP, dirP)
        {
            this.CodeE = codeE;
            this.nameCarreraE = nameCarreraE;
        }

        public string CodeEProp { get => CodeE; set => CodeE = value; }
        public string NameCarreraEProp { get => nameCarreraE; set => nameCarreraE = value; }
    }
}