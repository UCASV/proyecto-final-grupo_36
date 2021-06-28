using System;
using System.Windows.Forms;
using SALUDGODSV.Functions;
using SALUDGODSV.Models;
using SALUDGODSV.Context;
using System.Collections.Generic;
using System.Linq;

namespace SALUDGODSV.View
{
    public partial class RegistroDeCabina : Form
    {
        public RegistroDeCabina()
        {
            InitializeComponent();
        }

        public string Username { get; set; } 
        public string Password { get; set; }

        private void RegistroDeCabina_Load(object sender, EventArgs e)
        {
            lblSignos3Warning.Visible = false;
            lblVacio3Warning.Visible = false;
        }

        private void btnRegistrarCabina_Click(object sender, EventArgs e)
        {
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
                    var auxNumber = Convert.ToInt32(txtTelefono.Text); //verificar q no tenga letras el telefono!
                    lblSignos3Warning.Visible = false;

                    var auxUser = txtUsuarioCabina.Text;
                    var auxContra = txtContraCabina.Text;
                    if (Username.CompareTo(auxUser) == 0 && Password.CompareTo(auxContra) == 0)
                    {
                        try
                        {
                            var db = new covidcontext();
                            var auxCabin = new Cabin
                            {

                                Phone = auxNumber,
                                Caretaker = txtNombreEncargado.Text,
                                City = cmbCiudad.SelectedItem.ToString(),
                                Departament = cmbDepartamento.SelectedItem.ToString(),
                                Mail = txtCorreo.Text
                            };
                            db.Add(auxCabin);
                            db.SaveChanges();

                            try 
                            {
                                List<Cabin> cabinas = db.Cabins.ToList();
                                var verifyEmployees = db.Employees.ToList().Count > 0;
                                var auxManager = new Manager()
                                {
                                    User = Username,
                                    Password = Password,
                                    CodeCabin = cabinas[0].Code
                                };
                                db.Add(auxManager);
                                db.SaveChanges();
                                MessageBox.Show("¡Su usuario ha sido registrado con exito!", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                switch(verifyEmployees)
                                {
                                    case true:
                                        using(var auxLoginEmployees = new IngresarEmpleado())
                                        {
                                            Hide();
                                            auxLoginEmployees.ShowDialog();
                                            Show();
                                        }
                                        break;
                                    case false:
                                        MessageBox.Show("No se ha detectado ningun empleado registrado en su base de datos, pasaremos a registrar uno", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        using(var auxRegisterEmployee = new RegistrarEmpleado())
                                        {
                                            Hide();
                                            auxRegisterEmployee.ShowDialog();
                                            Show();
                                        }
                                        break;
                                }
                            }
                            catch (Exception v)
                            {
                                MessageBox.Show("Un error ha ocurrido", "Ministerio De Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ocurrio un error al usar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                      MessageBox.Show("Su Usuario o Contraseña no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Departament(cmbDepartamento.SelectedIndex);//Cuando el valor del combobox de departamentos cambie
        }
        private void Selected_Departament(int auxiliarIndex)
        {//Elije el caso de departamento y acopla los municipios a ese caso de departamento
            switch (auxiliarIndex)
            {
                case 0:
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
                    cmbCiudad.Items.Clear();
                    cmbCiudad.Items.AddRange(new object[]
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
