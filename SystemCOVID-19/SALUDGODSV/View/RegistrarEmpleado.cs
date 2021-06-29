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
    public partial class RegistrarEmpleado : Form
    {
        public RegistrarEmpleado()
        {
            InitializeComponent();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                var auxName = txtInsertName.Text;
                StringVerifications.VerifyString(auxName);
                var auxEmail = txtInsertEmail.Text;
                var auxDirection = txtInsertDirection.Text;
                StringVerifications.VerifyString(auxDirection);
                var auxEmployee = txtInsertEmployee.Text;
                StringVerifications.VerifyString(auxEmployee);
                var auxAnswer = txtInsertAnswer.Text;
                StringVerifications.VerifyString(auxAnswer);
                
                try
                {
                    var db = new covidcontext();
                    var managerList = db.Managers.ToList();
                    var auxEmployeeVar = new Employee()
                    {
                        Name = auxName,
                        Mail = auxEmail,
                        City = auxDirection,
                        Departament = "",
                        Occupation = auxEmployee,
                        ManagerCode = managerList[0].Code,
                        SecurityAnswer = auxAnswer,
                        CodeSecurityQuestion = Convert.ToInt32(cmbInsertQuestion.SelectedIndex.ToString())+1
                    };
                    db.Add(auxEmployeeVar);
                    db.SaveChanges();
                    var auxEmployees = db.Employees.ToList();
                    var lastEmployee = auxEmployees.Last();
                    MessageBox.Show($"Felicidades, su empleado a ha sido registrado, su ID es : {lastEmployee.Code}", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using(var auxLogin = new IngresarEmpleado())
                    {
                        Hide();
                        auxLogin.ShowDialog();
                        Show();
                    }
                }
                catch ( Exception asd)
                {
                    MessageBox.Show(asd.ToString(), "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Un error ha ocurrido, verifique haber introducido explicitamente texto en los cuadros correspondientes", "Ministerio de Salud",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void RegistrarEmpleado_Load(object sender, EventArgs e)
        {
            var db = new covidcontext();
            var questionsList = db.SecurityQuestions.ToList();
            cmbInsertQuestion.DataSource = null;
            cmbInsertQuestion.ValueMember = "Code";
            cmbInsertQuestion.DisplayMember = "SecurityQuestion1";
            cmbInsertQuestion.DataSource = questionsList;
        }
    }
}
