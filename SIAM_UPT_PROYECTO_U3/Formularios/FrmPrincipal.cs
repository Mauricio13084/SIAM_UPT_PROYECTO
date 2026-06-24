using SIAM_UPT_PROYECTO_U3.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIAM_UPT_PROYECTO_U3.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Text = "SIAM - Sistema de Monitoreo Ambiental FAING";
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1200, 700);

            // Cargar FrmInicio por defecto
            CargarFormulario(new FrmInicio());
        }
        private void CargarFormulario(Form formHijo)
        {
            panelContenido.Controls.Clear();   // Limpia lo que había antes

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            CargarFormulario(new FrmInicio());
        }
    }
}
