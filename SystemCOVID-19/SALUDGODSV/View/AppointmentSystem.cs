using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SALUDGODSV.Functions;
using System.Windows.Forms;
using SALUDGODSV.Models;
using SALUDGODSV.Context;

namespace SALUDGODSV.View
{
    public partial class AppointmentSystem : Form
    {
        public AppointmentSystem()
        {
            InitializeComponent();
        }

        private const int CB_SETCUEBANNER = 0x1703;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        private void AppointmentSystem_Load(object sender, EventArgs e)
        {
            SendMessage(cmbDepartaments.Handle, CB_SETCUEBANNER, 0, "Departamento");
            SendMessage(cmbCity.Handle, CB_SETCUEBANNER, 0, "Municipio");
            string toBackColor = "#1b1f7a", toBackColor2 = "#4b4dbc";
            Color myColor = ColorTranslator.FromHtml(toBackColor);
            Color myColor2 = ColorTranslator.FromHtml(toBackColor2);
            BackColor = myColor;
            tlpToMainDesign.BackColor = myColor2;
            btnNewAppointment.BackColor = myColor2;
            AppointmentSystem_StartVars();

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
                    if (txtInsertGobNumber.Text.CompareTo("") != 0)
                    {
                        try
                        {
                            Convert.ToInt32(txtInsertGobNumber.Text);
                            lblGeneralWarningTwo.Visible = false;
                        }
                        catch
                        {
                            lblGeneralWarningTwo.Visible = true;
                        }
                    }
                    lblGeneralWarningTwo.Visible = false;
                    try
                    {
                        var auxiliarDateTime = Convert.ToDateTime(dtpBirtrhday);
                        var auxiliarAge = DateTime.Now.Year - auxiliarDateTime.Year;
                       
                        if (DateTime.Now.DayOfYear < auxiliarDateTime.DayOfYear)
                            auxiliarAge -= 1;

                        var startDate = DateTime.Today;
                        var finalDdate = new DateTime(2022, 1, 1);
                        var randomDate = new Random();
                        var randomRange = (startDate - finalDdate).Days;
                        var AppointmentDate = startDate.AddDays(randomDate.Next(randomRange));

                        var db = new covidcontext();
                        var auxCitizen = new Citizen
                        {
                            Dui = auxiliarDuiNumber,
                            Name = txtInsertName.Text + " " + txtInsertLastNames.Text,
                            Mail = txtInsertEmail.Text,
                            City = cmbCity.SelectedItem.ToString(),
                            Departament = cmbDepartaments.SelectedItem.ToString(),
                            Phone = Convert.ToInt32(txtInsertPhoneNumer.Text),
                            Age = auxiliarAge,
                            AssociateNumber = Convert.ToInt32(txtInsertGobNumber.Text),
                            
                        };


                    }
                    catch
                    {
                        MessageBox.Show("Ocurrio un error al usar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void AppointmentSystem_StartVars()
        {
            lblGeneralWarning.Visible = false;
            lblGeneralWarningTwo.Visible = false;
            txtMedicalRecord.Text = null;
            txtInsertName.Text = null;
            txtInsertLastNames.Text = null;
            txtInsertEmail.Text = null;
            txtInsertPhoneNumer.Text = null;
            txtInsertDUI.Text = null;
            txtInsertGobNumber.Text = null;
        }

        private void cmbDepartaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Departament(cmbDepartaments.SelectedIndex);
        }
        private void Selected_Departament(int auxiliarIndex)
        {
            switch(auxiliarIndex)
            {
                case 0:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[] 
                    {
                        "Ahuachapán",
                        "Apaneca",
                        "Atiquizaya",
                        "Concepción de Ataco",
                        "El Refugio",
                        "Guaymango",
                        "Jujutla",
                        "San Francisco Menéndez",
                        "San Lorenzo",
                        "San Pedro Puxtla",
                        "Tacuba",
                        "Turín"
                    });
                    break;
                case 1:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Sensuntepeque",
                        "Cinquera",
                        "Dolores",
                        "Guacotecti",
                        "Ilobasco",
                        "Jutiapa",
                        "San Isidro",
                        "Tejutepeque",
                        "Victoria"
                    });
                    break;
                case 2:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Chalatenango",
                        "Arcatao",
                        "Azacualpa",
                        "Cancasque",
                        "Citalá",
                        "Comalapa",
                        "Concepción Quezaltepeque",
                        "Dulce Nombre de María",
                        "El Carrizal",
                        "El Paraíso",
                        "La Laguna",
                        "La Palma",
                        "La Reina",
                        "Las Flores",
                        "Las Vueltas",
                        "Nombre de Jesús",
                        "Nueva Concepción",
                        "Nueva Trinidad",
                        "Ojos de Agua",
                        "Potonico",
                        "San Antonio de la Cruz",
                        "San Antonio Los Ranchos",
                        "San Fernando",
                        "San Francisco Lempa",
                        "San Francisco Morazán",
                        "San Ignacio",
                        "San Isidro Labrador",
                        "San Luis del Carmen",
                        "San Miguel de Mercedes",
                        "San Rafael",
                        "Santa Rita",
                        "Tejutla"
                    });
                    break;
                case 3:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Cojutepeque",
                        "Candelaria",
                        "El Carmen",
                        "El Rosario",
                        "Monte San Juan",
                        "Oratorio de Concepción",
                        "San Bartolomé Perulapía",
                        "San Cristóbal",
                        "San José Guayabal",
                        "San Pedro Perulapán",
                        "San Rafael Cedros",
                        "San Ramón",
                        "Santa Cruz Analquito",
                        "Santa Cruz Michapa",
                        "Suchitoto",
                        "Tenancingo"
                    });
                    break;
                case 4:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Santa Tecla",
                        "Antiguo Cuscatlán",
                        "Chiltiupán",
                        "Ciudad Arce",
                        "Colón",
                        "Comasagua",
                        "Huizúcar",
                        "Jayaque",
                        "Jicalapa",
                        "La Libertad",
                        "Nuevo Cuscatlán",
                        "Quezaltepeque",
                        "San Juan Opico",
                        "Sacacoyo",
                        "San José Villanueva",
                        "San Matías",
                        "San Pablo Tacachico",
                        "Talnique",
                        "Tamanique",
                        "Teotepeque",
                        "Tepecoyo",
                        "Zaragoza"
                    });
                    break;
                case 5:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Zacatecoluca",
                        "Cuyultitán",
                        "El Rosario",
                        "Jerusalén",
                        "Mercedes La Ceiba",
                        "Olocuilta",
                        "Paraíso de Osorio",
                        "San Antonio Masahuat",
                        "San Emigdio",
                        "San Francisco Chinameca",
                        "San Pedro Masahuat",
                        "San Juan Nonualco",
                        "San Juan Talpa",
                        "San Juan Tepezontes",
                        "San Luis La Herradura",
                        "San Luis Talpa",
                        "San Miguel Tepezontes",
                        "San Pedro Nonualco",
                        "San Rafael Obrajuelo",
                        "Santa María Ostuma",
                        "Santiago Nonualco",
                        "Tapalhuaca"
                    });
                    break;
                case 6:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "La Unión",
                        "Anamorós",
                        "Bolívar",
                        "Concepción de Oriente",
                        "Conchagua",
                        "El Carmen",
                        "El Sauce",
                        "Intipucá",
                        "Lislique",
                        "Meanguera del Golfo",
                        "Nueva Esparta",
                        "Pasaquina",
                        "Polorós",
                        "San Alejo",
                        "San José",
                        "Santa Rosa de Lima",
                        "Yayantique",
                        "Yucuaiquín"
                    });
                    break;
                case 7:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "San Francisco Gotera",
                        "Arambala",
                        "Cacaopera",
                        "Chilanga",
                        "Corinto",
                        "Delicias de Concepción",
                        "El Divisadero",
                        "El Rosario",
                        "Gualococti",
                        "Guatajiagua",
                        "Joateca",
                        "Jocoaitique",
                        "Jocoro",
                        "Lolotiquillo",
                        "Meanguera",
                        "Osicala",
                        "Perquín",
                        "San Carlos",
                        "San Fernando",
                        "San Isidro",
                        "San Simón",
                        "Sensembra",
                        "Sociedad",
                        "Torola",
                        "Yamabal",
                        "Yoloaiquín"
                    });
                    break;
                case 8:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "San Miguel",
                        "Carolina",
                        "Chapeltique",
                        "Chinameca",
                        "Chirilagua",
                        "Ciudad Barrios",
                        "Comacarán",
                        "El Tránsito",
                        "Lolotique",
                        "Moncagua",
                        "Nueva Guadalupe",
                        "Nuevo Edén de San Juan",
                        "Quelepa",
                        "San Antonio",
                        "San Gerardo",
                        "San Jorge",
                        "San Luis de la Reina",
                        "San Rafael Oriente",
                        "Sesori",
                        "Uluazapa"
                    });
                    break;
                case 9:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "San Salvador",
                        "Aguilares",
                        "Apopa",
                        "Ayutuxtepeque",
                        "Ciudad Delgado",
                        "Cuscatancingo",
                        "El Paisnal",
                        "Guazapa",
                        "Ilopango",
                        "Mejicanos",
                        "Nejapa",
                        "Panchimalco",
                        "Rosario de Mora",
                        "San Marcos",
                        "San Martín",
                        "Santiago Texacuangos",
                        "Santo Tomás",
                        "Soyapango",
                        "Tonacatepeque"
                    });
                    break;
                case 10:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "San Vicente",
                        "Apastepeque",
                        "Guadalupe",
                        "San Cayetano Istepeque",
                        "San Esteban Catarina",
                        "San Ildefonso",
                        "San Lorenzo",
                        "San Sebastián",
                        "Santa Clara",
                        "Santo Domingo",
                        "Tecoluca",
                        "Tepetitán",
                        "Verapaz"
                    });
                    break;
                case 11:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Santa Ana",
                        "Candelaria de la Frontera",
                        "Chalchuapa",
                        "Coatepeque",
                        "El Congo",
                        "El Porvenir",
                        "Masahuat",
                        "Metapán",
                        "San Antonio Pajonal",
                        "San Sebastián Salitrillo",
                        "Santa Rosa Guachipilín",
                        "Santiago de la Frontera",
                        "Texistepeque"
                    });
                    break;
                case 12:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Sonsonate",
                        "Acajutla",
                        "Armenia",
                        "Caluco",
                        "Cuisnahuat",
                        "Izalco",
                        "Juayúa",
                        "Nahuizalco",
                        "Nahulingo",
                        "Salcoatitán",
                        "San Antonio del Monte",
                        "San Julián",
                        "Santa Catarina Masahuat",
                        "Santa Isabel Ishuatán",
                        "Santo Domingo de Guzmán",
                        "Sonzacate"
                    });
                    break;
                case 13:
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(new object[]
                    {
                        "Usulután",
                        "Alegría",
                        "Berlín",
                        "California",
                        "Concepción Batres",
                        "El Triunfo",
                        "Ereguayquín",
                        "Estanzuelas",
                        "Jiquilisco",
                        "Jucuapa",
                        "Jucuarán",
                        "Mercedes Umaña",
                        "Nueva Granada",
                        "Ozatlán",
                        "Puerto El Triunfo",
                        "San Agustín",
                        "San Buenaventura",
                        "San Dionisio",
                        "San Francisco Javier",
                        "Santa Elena",
                        "Santa María",
                        "Santiago de María",
                        "Tecapán"
                    });
                    break;
            }
        }
    }
}