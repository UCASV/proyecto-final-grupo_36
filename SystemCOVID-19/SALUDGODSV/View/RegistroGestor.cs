using System;
using System.Windows.Forms;
using SALUDGODSV.Functions;

namespace SALUDGODSV.View
{
    public partial class RegistroGestor : Form
    {
        public RegistroGestor()
        {
           InitializeComponent();
        }

        private void RegistroGestor_Load(object sender, EventArgs e)
        {
            lblSignos2Warning.Visible = false;
            lblVacio2Warning.Visible = false;
        }

        private void btnRegistrarGestor_Click(object sender, EventArgs e)
        {
            try
            {
                lblSignos2Warning.Visible = false;
                lblVacio2Warning.Visible = false;
                if (txtUsuarioGReg.Text.CompareTo("") == 0 || txtContraGReg.Text.CompareTo("") == 0)
                {
                    lblVacio2Warning.Visible = true;
                }
                else
                {
                    lblVacio2Warning.Visible = false;
                    StringVerifications.VerifyString(txtUsuarioGReg.Text);
                    StringVerifications.VerifyString(txtContraGReg.Text);
                    lblSignos2Warning.Visible = false;

                    try
                    {

                        MessageBox.Show($"Sus credenciales han sido registradas {txtUsuarioGReg.Text}, bienvenido", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (var newRegistroDeCabina = new RegistroDeCabina())
                        {
                            Hide();
                            newRegistroDeCabina.Username = txtUsuarioGReg.Text;
                            newRegistroDeCabina.Password = txtContraGReg.Text;
                            newRegistroDeCabina.ShowDialog();
                            newRegistroDeCabina.Close();
                            Show();
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Hubo un problema al registrar sus datos, lo sentimos", "Ministerio De Salud",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                lblSignos2Warning.Visible = true;
            }
        }

  
    }
                

}

