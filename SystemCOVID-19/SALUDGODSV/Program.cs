using System;
using System.Windows.Forms;
using SALUDGODSV.View;
using SALUDGODSV.Models;
using SALUDGODSV.Context;
using System.Linq;
using System.Collections.Generic;

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
            //Application.Run(new AppointmentSystem());

            //Abrir un form dependiendo a si existen usuarios o no.
            var db = new covidcontext();
            List<Manager> auxManager = db.Managers.ToList();
            if(auxManager.Count == 0)
            {
                Application.Run(new RegistroGestor());
            }
            else
            {
                Application.Run(new IniciandoGestor());
            }
        }
    }
}
