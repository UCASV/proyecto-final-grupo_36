using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SALUDGODSV.Models;
using SALUDGODSV.Context;
using SALUDGODSV.Functions;

namespace SALUDGODSV.View
{
    public partial class IngresarEmpleado : Form
    {
        public IngresarEmpleado()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new covidcontext();

                StringVerifications.VerifyString(txtInsertAnswer.Text);
                var auxAnswer = txtInsertAnswer.Text;
                Employee globalEmployee = (from aux in db.Employees
                                        where aux.Code == Convert.ToInt32(txtInsertID.Text)
                                        select aux).First();

                switch(auxAnswer.CompareTo(globalEmployee.SecurityAnswer) == 0)
                {
                    case true:
                        var auxAccesLog = new AccessLog()
                        {
                            Date = DateTime.Today,
                            Hour = TimeSpan.FromMinutes(DateTime.Today.Minute),
                            EmployeeCode = globalEmployee.Code
                        };

                        db.Add(auxAccesLog);
                        db.SaveChanges();

                        MessageBox.Show("Sus credenciales han sido verificadas, ¡bienvenido!", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using(var auxAppointmentSystem = new AppointmentSystem())
                        {
                            Hide();
                            auxAppointmentSystem.globalEmployeeSystem = globalEmployee.Code;
                            auxAppointmentSystem.ShowDialog();
                            Show();
                        }
                        break;
                    case false:
                        MessageBox.Show("Sus credenciales son incorrectas", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Uno de los campos ingresados no corresponde con su tipo", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInsertID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var db = new covidcontext();
                var auxID = Convert.ToInt32(txtInsertID.Text);
                var auxEmployees = db.Employees.ToList();
                var checkEmployee = auxEmployees.Where(u => u.Code == auxID).ToList().Count() > 0;
                switch (checkEmployee)
                {
                    case true:
                        Employee forQuestion = (from aux in db.Employees
                                                where aux.Code == auxID
                                                select aux).First();
                        var auxQuestions = db.SecurityQuestions.ToList();
                        lblShowQuestion.Text = auxQuestions[forQuestion.CodeSecurityQuestion].SecurityQuestion1;
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Ha ingresado un ID invalido", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var auxiliarRegister = new RegistrarEmpleado())
            {
                Hide();
                auxiliarRegister.ShowDialog();
                Show();
            }
        }
    }
}
