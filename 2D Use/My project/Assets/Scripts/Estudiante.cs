using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PackagePersona
{
    public class Estudiante : Persona
    {
        private string _code;
        private string _nameCarrera;

        public string Code
        {
            get => _code;
            set => _code = value;
        }

        public string NameCarrera
        {
            get => _nameCarrera;
            set => _nameCarrera = value;
        }
       

        // Si Persona tiene un constructor con parámetros, llama a base(...)
        public Estudiante(string code, string nameCarrera, string nameP)
        {
            _code = code;
            _nameCarrera = nameCarrera;
        }

        // Si necesitas pasar parámetros a Persona, descomenta y ajusta:
        // public Estudiante(string code, string nameCarrera, string nameP, string mailP, string dirP)
        //     : base(nameP, mailP, dirP)
        // {
        //     _code = code;
        //     _nameCarrera = nameCarrera;
        // }
    }
}
