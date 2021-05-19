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
    public partial class MiAgenda : Form
    {
        public MiAgenda()
        {
            InitializeComponent();
            llenarLista();
        }

        public void llenarLista()
        {
            StreamReader fichero = null;
            String linea;
            try
            {
                cbLista.Items.Clear();
                fichero = File.OpenText("agenda.txt");
                linea = fichero.ReadLine();
                while (linea != null)
                {
                    String[] trozos = linea.Split(':');
                    cbLista.Items.Add(trozos[0]);
                    linea = fichero.ReadLine();
                }
            }
            catch
            {
            }
            finally
            {

                try {if(fichero!=null) fichero.Close(); } catch { }
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Datos ventana = new Datos(this);
            ventana.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String nombre;
            String telefono;
            if (cbLista.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un nombre de la lista");
            }
            else { nombre= cbLista.SelectedItem.ToString();
                telefono = buscarContacto(nombre);
                MessageBox.Show("Telefono: " + telefono);
            }
        }

        private string buscarContacto(string nombre)
        {
            String telefono="";
            StreamReader fichero = null;
            String linea;

           
            fichero = File.OpenText("agenda.txt");
            linea = fichero.ReadLine();
            while (linea != null)
            {
                String[] trozos = linea.Split(':');
                if (nombre.Equals(trozos[0])) {
                    telefono = trozos[1];
                }
                linea = fichero.ReadLine();
            }
            fichero.Close();

            return telefono;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String nombre;
            String telefono;
            if (cbLista.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un nombre de la lista");
            }
            else
            {
                nombre = cbLista.SelectedItem.ToString();
                telefono = buscarContacto(nombre);
                Datos ventana = new Datos(this,nombre,telefono);
                ventana.Show();
            }
           
        }
    }
}
