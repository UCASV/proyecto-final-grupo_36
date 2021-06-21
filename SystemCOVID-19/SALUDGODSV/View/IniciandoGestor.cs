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

namespace SALUDGODSV
{
    public partial class IniciandoGestor : Form
    {
        public IniciandoGestor()
        {
            InitializeComponent();
        }

        private void btnIngresarGestor_Click(object sender, EventArgs e)
        {
            lblSignosWarning.Visible = false;
            lblVacioWarning.Visible = false;
            try
            {
                StringVerifications.VerifyString(txtUsuarioG.Text);
                StringVerifications.VerifyString(txtContraG.Text);
                lblSignosWarning.Visible = true;
                    
            }
            catch
            {
               lblVacioWarning.Visible = true;
            }
            lblSignosWarning.Visible = false;
            
        }
    }
}







