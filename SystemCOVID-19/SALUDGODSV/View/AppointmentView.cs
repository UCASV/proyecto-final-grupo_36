using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SALUDGODSV.View
{
    public partial class AppointmentView : Form
    {
        public AppointmentView()
        {
            InitializeComponent();
        }

        private void AppointmentView_Load(object sender, EventArgs e)
        {
            string toBackColor = "#1b1f7a", toBackColor2 = "#4b4dbc";
            Color myColor = System.Drawing.ColorTranslator.FromHtml(toBackColor);
            Color myColor2 = System.Drawing.ColorTranslator.FromHtml(toBackColor2);
            BackColor = myColor;
            grpAppointmentView.BackColor = myColor2;
            btnAddToQueue.BackColor = myColor2;
            btnVacunar.BackColor = myColor2;
            btnShowInformation.BackColor = myColor2;
        }

        private void AppointmentView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}
