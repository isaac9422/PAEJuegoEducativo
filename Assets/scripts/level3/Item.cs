using UnityEngine;
using System.Collections;

namespace Juego
{
    public class Item
    {
        private string nombre;
        private float velocidad;
        private bool esCorrecta;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public float Velocidad
        {
            get
            {
                return velocidad;
            }
            set
            {
                velocidad = value;
            }
        }

        public bool EsCorrecta
        {
            get
            {
                return esCorrecta;
            }
            set
            {
                esCorrecta = value;
            }
        }
    }

}