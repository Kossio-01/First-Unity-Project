using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackagesPesona 
{
    [System.Serializable]
    public class Persona
    {
        private string nameP;
        private string mailP;  // Mantener como string
        private string dirP;   // Mantener como string

        public Persona(){}
        
        public Persona(string nameP, string mailP, string dirP)
        {
            this.nameP = nameP;
            this.mailP = mailP;
            this.dirP = dirP;
        }

        public string NameP { get => nameP; set => nameP = value; }
        public string MailP { get => mailP; set => mailP = value; }
        public string DirP { get => dirP; set => dirP = value; }
    }
}
