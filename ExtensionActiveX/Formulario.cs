using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtensionActiveX
{
    public partial class Formulario : Form
    {
        public delegate void ManejadorFormulario(string estado);
        public event ManejadorFormulario eventoFormulario;

        //Manejo de 
        public List<String> filasListBox = new List<string>(1);

        public Formulario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( eventoFormulario != null )
                eventoFormulario("ACEPTAR");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (eventoFormulario != null)
                eventoFormulario("IMPRIMIR");
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            //Cargando el formulario
            //int filascantidad = filasListBox.Count;
            //if (filascantidad > 0)
            //{
            //    for (int i = 0; i < filasListBox.Count; i++)
            //    { 
            //        //Iterando filas
            //    }
            //}
        }

        
    }
}
