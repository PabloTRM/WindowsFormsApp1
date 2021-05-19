using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Datos : Form
    {
        MiAgenda principal;
        bool modificar;
        String buscar;
        List<Contacto> lista = new List<Contacto>();

        public Datos(MiAgenda p)
        {
            InitializeComponent();
            principal = p;
            modificar = false;
        }

        public Datos(MiAgenda p, String nombre, String telefono)
        {
            InitializeComponent();
            principal = p;
            modificar = true;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono;
            
            buscar = nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtTelefono.Text != "")
            {
                if (!modificar)
                {
                    StreamWriter fichero;
                    fichero = File.AppendText("agenda.txt");
                    fichero.WriteLine(txtNombre.Text + ":" + txtTelefono.Text);
                    fichero.Close();
                }
                else
                {
                    //volcar el fichero a una lista
                    volcarFichero();
                    //modificar la lista
                    modificarLista();
                    //volcar la lista en el fichero
                    volcarLista();
                }
               

                txtNombre.Clear();
                txtTelefono.Clear();

                principal.llenarLista();
            }
            else { MessageBox.Show("te faltan campos por llenar"); }
        }

        private void volcarLista()
        {
            StreamWriter fichero;
            fichero = File.CreateText("agenda.txt");
            foreach (Contacto c in lista)
            {
                fichero.WriteLine(c.Nombre + ":" + c.Telefono);
            }
             fichero.Close();
            } 

        private void modificarLista()
        {
            foreach (Contacto c in lista)
            {
                if (c.Nombre.Equals(buscar))
                {
                    c.Nombre = txtNombre.Text;
                    c.Telefono = txtTelefono.Text;
                }
            }
        }

        private void volcarFichero()
        {
            StreamReader fichero;
            String linea;

            fichero = File.OpenText("agenda.txt");
            linea = fichero.ReadLine();
            while (linea != null)
            {
                String[] trozos = linea.Split(':');
                lista.Add(new Contacto(trozos[0], trozos[1]));
                linea = fichero.ReadLine();
            }
            fichero.Close();
        }
    }
}
