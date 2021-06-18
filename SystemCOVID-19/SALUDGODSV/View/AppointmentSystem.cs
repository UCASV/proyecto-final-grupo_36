using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            lblWarningOne.Visible = false;
            lblWarningTwo.Visible = false;
            lblWarningThree.Visible = false;
            lblWarningFour.Visible = false;
            lblWarningFive.Visible = false;
            lblWarningSix.Visible = false;
            lblGeneralWarning.Visible = false;
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

    }
}
