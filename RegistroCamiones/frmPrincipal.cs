using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;

namespace RegistroCamiones
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnnuevaorden_Click(object sender, EventArgs e)
        {
            frmOrden orden = new frmOrden();
            orden.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmActualizar actualizar = new frmActualizar();
            actualizar.Show();
        }

 

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Agregar sg = new Agregar();
            sg.Show();
        }
    }
}
