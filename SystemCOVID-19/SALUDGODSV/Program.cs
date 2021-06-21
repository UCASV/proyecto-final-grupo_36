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
            Application.Run(new AppointmentSystem());
<<<<<<< HEAD

=======
=======
            Application.Run(new IniciandoGestor());
>>>>>>> 51e4ad71c5ded144429eb98b3ae81d189e9d4a4f
>>>>>>> 10c29ffa429b3b506166fe2916b38a60eaf9e14e
        }
    }
}
