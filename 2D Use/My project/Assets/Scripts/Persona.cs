using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackagesPesona 
{
    [System.Serializable]
    public class Persona
    {
        private string nameP;
        private int mailP;
        private int dirP;

    public Persona(){}
        public Persona(string nameP, int mailP, int dirP)
        {
            this.nameP = nameP;
            this.mailP = mailP;
            this.dirP = dirP;
        }

        public string NameP { get => nameP; set => nameP = value; }
        public int MailP { get => mailP; set => mailP = value; }
        public int DirP { get => dirP; set => dirP = value; }
    }
}
