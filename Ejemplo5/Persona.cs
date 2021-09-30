using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo5
{
    public class Persona
    {
         private string nombre;
        private string apellido;
        private string telefono;
        private string correo;
        private string columna;

        //metodos
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Columna
        {
            get { return columna; }
            set { columna = value; }
        }
    }



}

    

