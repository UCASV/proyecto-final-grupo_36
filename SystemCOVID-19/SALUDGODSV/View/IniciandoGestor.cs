using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SALUDGODSV.Functions;
using SALUDGODSV.Models;
using SALUDGODSV.Context;

namespace SALUDGODSV.View
{
    public partial class IniciandoGestor : Form
    {
        public IniciandoGestor()
        {
            InitializeComponent();
        }

        private void btnIngresarGestor_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUsuarioG.Text.CompareTo("") == 0 || txtContraG.Text.CompareTo("") == 0)
                {
                    lblVacioWarning.Visible = true;
                }
                else
                {
                    lblVacioWarning.Visible = false;
                    StringVerifications.VerifyString(txtUsuarioG.Text);
                    StringVerifications.VerifyString(txtContraG.Text);
                    lblSignosWarning.Visible = false;

                    try
                    {

                        var db = new covidcontext();
                        List<Manager> auxManager = db.Managers.ToList();

                        if(auxManager.Count == 0 )
                        {
                            MessageBox.Show("Su usuario no existe! Pasaremos a registrarlo", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (var newRegistroGestor = new RegistroGestor())
                            {
                                Hide();
                                newRegistroGestor.ShowDialog();
                                
                                Show();
                            }

                        }

                        bool check = auxManager
                        .Where(u => u.User == txtUsuarioG.Text &&
                               u.Password == txtContraG.Text)
                        .ToList().Count() > 0;

                        if (check)
                        {
                            MessageBox.Show($"Sus credenciales han sido confirmadas {txtUsuarioG}, bienvenido", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (var newAppointmentSystem = new AppointmentSystem())
                            {
                                Hide();
                                newAppointmentSystem.ShowDialog();
                                newAppointmentSystem.Close();
                                Close();
                            }
                        }
                        else
                        MessageBox.Show("Las credenciales no coinciden!", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {

                    }
                }       
            }
            catch
            {
                lblSignosWarning.Visible = true;
            }
        }

        private void IniciandoGestor_Load(object sender, EventArgs e)
        {
            lblSignosWarning.Visible = false;
            lblVacioWarning.Visible = false;
        }
    }
}







