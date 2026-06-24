using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIAM_UPT_PROYECTO_U3
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo700,      // Color principal
                Primary.Indigo900,
                Primary.BlueGrey500,
                Accent.LightBlue200,    // Color acento
                TextShade.WHITE);

            Application.Run(new Formularios.FrmLogin());
        }
    }
}
