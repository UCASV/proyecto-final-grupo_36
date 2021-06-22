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

        //Variable global utilizada para verificar y obtener datos (Por medio de estos puede consultar cosas en la base de datos)
        public AppointmentSystem.toDataGridView GlobalStruct {get; set;}
        private void AppointmentView_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(GlobalStruct.appointmentDgvName, "Mostrando nombre", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            string toBackColor = "#1b1f7a", toBackColor2 = "#4b4dbc";
            Color myColor = ColorTranslator.FromHtml(toBackColor);
            Color myColor2 = ColorTranslator.FromHtml(toBackColor2);
            BackColor = myColor;
            grpAppointmentView.BackColor = myColor2;
            btnAddToQueue.BackColor = myColor2;
            btnVacunar.BackColor = myColor2;
            btnShowInformation.BackColor = myColor2;
        }
    }
}
