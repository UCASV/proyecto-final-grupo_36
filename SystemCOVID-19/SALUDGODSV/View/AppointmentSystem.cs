using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SALUDGODSV.Functions;
using System.Windows.Forms;

namespace SALUDGODSV.View
{
    public partial class AppointmentSystem : Form
    {
        public AppointmentSystem()
        {
            InitializeComponent();
        }

        private void AppointmentSystem_Load(object sender, EventArgs e)
        {
            string toBackColor = "#1b1f7a", toBackColor2 = "#4b4dbc";
            Color myColor = System.Drawing.ColorTranslator.FromHtml(toBackColor);
            Color myColor2 = System.Drawing.ColorTranslator.FromHtml(toBackColor2);
            BackColor = myColor;
            tlpToMainDesign.BackColor = myColor2;
            btnNewAppointment.BackColor = myColor2;
            lblGeneralWarning.Visible = false;
            lblGeneralWarningTwo.Visible = false;
            string src = DateTime.Now.ToString("HH:mm");
            MessageBox.Show(src, "Hola", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvAppointmentRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Hide();
            using( var varToShow = new AppointmentView())
            {
                varToShow.Show();
            }
            Show();
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                StringVerifications.VerifyString(txtInsertEmail.Text);
                StringVerifications.VerifyString(txtInsertLastNames.Text);
                StringVerifications.VerifyString(txtInsertName.Text);
                StringVerifications.VerifyString(txtMedicalRecord.Text);
                try
                {
                    var auxiliarDuiNumber = Convert.ToInt32(txtInsertDUI.Text);
                    var auxiliarPhoneNumber = Convert.ToInt32(txtInsertPhoneNumer.Text);
                    var auxiliarGobNumber = Convert.ToInt32(txtInsertGobNumber.Text);
                    lblGeneralWarningTwo.Visible = false;
                }
                catch
                {
                    lblGeneralWarningTwo.Visible = true;
                }
                lblGeneralWarning.Visible = false;
            }
            catch
            {
                lblGeneralWarning.Visible = true;
            }
        }


    }
}
