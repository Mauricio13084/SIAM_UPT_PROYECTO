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
    public partial class FrmLogin : Form
    {
        int intentos = 0;
        public FrmLogin()
        {
            InitializeComponent();
            this.Text = "Acceso Administrativo - UPT FAING";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1100, 620);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(15, 23, 42);
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (txtUsuario.Text == "admin" && txtPassword.Text == "123")
            {
                MessageBox.Show("Bienvenido al sistema.",
                    "Acceso correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Hide();
                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();
            }
            else
            {
                intentos++;

                MessageBox.Show("Usuario o contraseña incorrectos. Intento " + intentos + " de 3.",
                    "Error de acceso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtUsuario.Text = string.Empty;
                txtPassword.Clear();
                txtUsuario.Focus();

                if (intentos >= 3)
                {
                    MessageBox.Show("Ha superado el número máximo de intentos. El acceso será bloqueado. Podrá acceder pasado 10 segundos.",
                        "Acceso bloqueado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    btnIngresar.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtUsuario.Enabled = false;

                    timerDesbloqueo.Start();
                }
            }
        }

        private void timerDesbloqueoClick_Tick(object sender, EventArgs e)
        {
            timerDesbloqueo.Stop();

            intentos = 0;

            btnIngresar.Enabled = true;
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;

            txtUsuario.Clear();
            txtPassword.Clear();
            txtUsuario.Focus();

            MessageBox.Show("El acceso ha sido habilitado nuevamente.");
        }
    }
}
