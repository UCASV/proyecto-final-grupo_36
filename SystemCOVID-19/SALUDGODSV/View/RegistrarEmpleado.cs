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
                StringVerifications.VerifyString(auxEmail);
                var auxDirection = txtInsertDirection.Text;
                StringVerifications.VerifyString(auxDirection);
                var auxEmployee = txtInsertEmployee.Text;
                StringVerifications.VerifyString(auxEmployee);
                var auxAnswer = txtInsertAnswer.Text;
                StringVerifications.VerifyString(auxAnswer);
                int auxAge = 0;
                try
                {
                    auxAge = Convert.ToInt32(txtInsertAge.Text);
                }
                catch
                {
                    MessageBox.Show("Ha introducido una edad incorrecta", "Ministerio de Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {

                }
                catch
                {

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
