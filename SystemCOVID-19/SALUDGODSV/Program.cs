using System;
using System.Windows.Forms;
using SALUDGODSV.View;

namespace SALUDGODSV
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new AppointmentSystem());
=======
            Application.Run(new IniciandoGestor());
>>>>>>> 51e4ad71c5ded144429eb98b3ae81d189e9d4a4f
        }
    }
}
