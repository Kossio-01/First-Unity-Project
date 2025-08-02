using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PackagePersona
{
    public class Persona
    {
        private string nameP;
        private int mailP;
        private int dirP;
        public Persona(string nameP, int mailP, int dirP)
        {
            this.nameP = nameP;
            this.mailP = mailP;
            this.dirP = dirP;
        }
    }
}