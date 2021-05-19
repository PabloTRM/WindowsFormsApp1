using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Contacto
    {
        private String nombre;
        private String telefono;

        public Contacto()
        {
        }

        public Contacto(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
