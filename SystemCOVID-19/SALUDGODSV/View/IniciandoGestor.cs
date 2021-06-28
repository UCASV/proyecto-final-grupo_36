using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                        bool check = auxManager
                        .Where(u => u.User == txtUsuarioG.Text &&
                               u.Password == txtContraG.Text)
                        .ToList().Count() > 0;

                        if (check)
                        {
                            MessageBox.Show($"Sus credenciales han sido confirmadas {txtUsuarioG}, bienvenido", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var checkEmployeesList = db.Employees.ToList().Count > 0;
                            switch(checkEmployeesList)
                            {
                                case true:
                                    using(var auxLogin = new IngresarEmpleado())
                                    {
                                        Hide();
                                        auxLogin.ShowDialog();
                                        Show();
                                    }
                                    break;

                                case false:
                                    using (var auxRegister = new RegistrarEmpleado())
                                    {
                                        Hide();
                                        auxRegister.ShowDialog();
                                        Show();
                                    }
                                    break;
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







