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
    public partial class RegistroDeCabina : Form
    {
        public RegistroDeCabina()
        {
            InitializeComponent();
        }

        public string Username { get; set; } //Voy a comprobar si son iguales a los q escribio en el Form anterior y despues guardarlos en la db
        public string Password { get; set; }

        private void RegistroDeCabina_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarCabina_Click(object sender, EventArgs e)
        {
            //Q no este vacio / lo de los signos para todo / Registrar la cabina (Hacer variable cabina y agrgarlo a la db con todos los atributos q tiene ademas del code cabin) = Asignar Code Cabin a Manager / Verificar el Usuario y Contra y guardarlos en la db
            try
            {   
                StringVerifications.VerifyString(txtNombreEncargado.Text);
                StringVerifications.VerifyString(txtUsuarioCabina.Text);
                StringVerifications.VerifyString(txtContraCabina.Text);
                try
                {
                    if(txtCorreo.Text.CompareTo("") != 0)
                    {
                        lblVacio3Warning.Visible = true;
                    }
                    var auxiliarNumero = Convert.ToInt32(txtTelefono.Text); //verificar q no tenga letras el telefono!
                    if (txtTelefono.Text.CompareTo("") != 0)
                    {
                        try
                        {
                            Convert.ToInt32(txtTelefono.Text);
                            lblSignos3Warning.Visible = false;
                        }
                        catch
                        {
                            lblSignos3Warning.Visible = true;
                        }
                    }
                    lblSignos3Warning.Visible = false;
                    
                    if (Username = txtUsuarioCabina.Text && Password = txtContraCabina.Text)
                    {
                        try//meter este try catch en un if del si user y contra son iguales
                        {

                            var db = new covidcontext();
                            List<Cabin> auxCabina = db.Cabins.ToList();
                            var auxCabin = new Cabin
                            {
                                Phone = txtTelefono.Text,
                                Caretaker = txtNombreEncargado.Text,
                                Code = auxCabina[0].Code
                            };


                        }
                        catch
                        {
                            MessageBox.Show("Ocurrio un error al usar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                catch
                {
                    lblSignos3Warning.Visible = true;
                }
                lblVacio3Warning.Visible = false;
            }
            catch
            {
                lblVacio3Warning.Visible = true;
            }
        }
    }
}
