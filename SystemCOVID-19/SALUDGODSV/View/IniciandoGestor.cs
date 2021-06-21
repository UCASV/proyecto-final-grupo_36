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
            try
            {
                StringVerifications.VerifyString(txtUsuarioG.Text);
                StringVerifications.VerifyString(txtContraG.Text);
                
                try
                {
                    var auxiliarUsuario = Convert.ToInt32(txtUsuarioG.Text);
                    var auxiliarContra = Convert.ToInt32(txtContraG.Text);
                    lblSignosWarning.Visible = false;
                }
                catch
                {
                    lblSignosWarning.Visible = true;
                }
                lblVacioWarning.Visible = false;
            }
            catch
            {
                lblVacioWarning.Visible = true;
            }
        }
    }
    }



