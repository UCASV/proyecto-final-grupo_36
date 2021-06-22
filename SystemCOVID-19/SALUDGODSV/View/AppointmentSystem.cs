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

        public struct toDataGridView
        {

            public int? appointmentDgvID { get; set; }
            public string appointmentDgvName { get; set; }
            public int appointmentDgvDui { get; set; }
            public int appointmentDgvAge { get; set; }
            public DateTime appointmentDgvDate { get; set; }
            public TimeSpan appointmentDgvTime { get; set; }
            public string appointmentDgvDose { get; set; }
        };


        private const int CB_SETCUEBANNER = 0x1703;

        //Para acceder a parametros internos del pc mediante user32.dll (No usar si no se explica un ejemplo)
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]

        //Funcion para realizar un cambio en el mensaje default de un comboboc
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        private void AppointmentSystem_Load(object sender, EventArgs e)
        {
            //Editando el texto de combobox departamentos
            SendMessage(cmbDepartaments.Handle, CB_SETCUEBANNER, 0, "Departamento");
            //Editando el texto de combobox municipios
            SendMessage(cmbCity.Handle, CB_SETCUEBANNER, 0, "Municipio");
            //Definiendo colores para convertilos en html y cambiar fondo de formulario
            string toBackColor = "#1b1f7a", toBackColor2 = "#4b4dbc";
            Color myColor = ColorTranslator.FromHtml(toBackColor);
            Color myColor2 = ColorTranslator.FromHtml(toBackColor2);
            BackColor = myColor;
            tlpToMainDesign.BackColor = myColor2;
            btnNewAppointment.BackColor = myColor2;
            //Funcion para iniciar variables con valores que no se repitan (O borrar lo que contienen)
            dgvToShowAppointments.BindingContext = BindingContext;
            AppointmentSystem_StartVars();

            /*Funcion para obtener la hora actual de la computadora (Usar para guardar el log de accesos de los empleados
            string src = DateTime.Now.ToString("HH:mm");
            MessageBox.Show(src, "Hola", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

        private void dgvToShowAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando se da clic sobre una celda del data grid view, llama al siguiente formulario
            Hide();
            var auxVar = new toDataGridView();

            //Extrae lo datos de la celda seleccionada actualmente para agregarlos a una struct usada en el datagridview del formulario anterior
            auxVar.appointmentDgvAge = Convert.ToInt32(dgvToShowAppointments.CurrentRow.Cells["appointmentDgvAge"].Value.ToString());
            auxVar.appointmentDgvDate = Convert.ToDateTime(dgvToShowAppointments.CurrentRow.Cells["appointmentDgvDate"].Value.ToString());
            auxVar.appointmentDgvDui = Convert.ToInt32(dgvToShowAppointments.CurrentRow.Cells["appointmentDgvDui"].Value.ToString());
            auxVar.appointmentDgvID = Convert.ToInt32(dgvToShowAppointments.CurrentRow.Cells["appointmentDgvID"].Value.ToString());
            auxVar.appointmentDgvName = dgvToShowAppointments.CurrentRow.Cells["appointmentDgvName"].Value.ToString();
            auxVar.appointmentDgvDose = dgvToShowAppointments.CurrentRow.Cells["appointmentDgvDose"].Value.ToString();
            auxVar.appointmentDgvTime = TimeSpan.Parse(dgvToShowAppointments.CurrentRow.Cells["appointmentDgvTime"].Value.ToString());

            using ( var varToShow = new AppointmentView())
            {
                //Iguala la variable global en AppointmentView para pasar los datos correctamente que se eligieron en el datagridview
                varToShow.GlobalStruct = auxVar;
                varToShow.ShowDialog();
            }
            Show(); 
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificacion de strings para no romper la base de datos
                //StringVerifications.VerifyString(txtInsertEmail.Text);
                StringVerifications.VerifyString(txtInsertLastNames.Text);
                StringVerifications.VerifyString(txtInsertName.Text);
                try
                {
                    //Convirtiendo texto a enteros
                    var auxiliarDuiNumber = Convert.ToInt32(txtInsertDUI.Text);
                    var auxiliarPhoneNumber = Convert.ToInt32(txtInsertPhoneNumer.Text);
                    if (txtInsertGobNumber.Text.CompareTo("") != 0)
                    {//Verificando si el numero de gobierno esta vacio
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
                        //Convirtiendo los datos obtenidos en la caja de las fechas para convertirnos en un DateTime utilizable
                        var auxiliarDateTime = Convert.ToDateTime(dtpBirtrhday.Text);
                        //Generando la resta de la fecha de nacimiento y la fecha actual para determinar la edad de la persona
                        var auxiliarAge = Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(auxiliarDateTime.Year.ToString());
                        //Ayuda a tener una edad exacta de la persona a la que se esta ingresando la cita
                        if (DateTime.Now.DayOfYear < auxiliarDateTime.DayOfYear)
                            auxiliarAge -= 1;
                        
                        //Invocando la db
                        var db = new covidcontext();
                        makeAppointment://Bloque de codigo
                        var startDate = DateTime.Today;//Definir la fecha actual
                        var finalDdate = new DateTime(2022, 1, 1);//Fecha limite para hacer citas
                        var randomDate = new Random();//Variable random
                        var randomRange = (finalDdate - startDate).Days;//Determinar los dias entre el ultimo dia para hacer citas y la fecha actual
                        var appointmentDate = startDate.AddDays(randomDate.Next(randomRange));//Elegir un numero random entre ese rango de días
                        var startHour = TimeSpan.FromHours(7);//Definicion de hora random
                        var endHour = TimeSpan.FromHours(11);//Definincion de hora random
                        var maxMinutes = (int)((endHour - startHour).TotalMinutes);//Randominar entre rangos de hora
                        var useMinutes = randomDate.Next(maxMinutes);
                        var appointmentHour = startHour.Add(TimeSpan.FromMinutes(useMinutes));//Realizar la conversion correcta al formato de hora

                        List<Appointment> verifyAppointments = db.Appointments.ToList();//Lista de citas realizadas
                        var checkRegister = verifyAppointments.Where(u => u.Date == appointmentDate && u.Hour == appointmentHour).ToList().Count() > 0;//Revisar si existe una cita a la misma hora y fecha
                        if (checkRegister)//Si esto pasa, regresa al bloque de codigo donde se definen las horas y fechas random para que de una hora y fecha valida
                            goto makeAppointment;

                        var auxiliarAppointment = new Appointment()
                        {//Si se creo con exito el appoointment, creamos la variable de appointment
                            Date = appointmentDate,
                            Hour = appointmentHour,
                            Dose = "1",
                            Street = "N/A",
                            City = cmbCity.SelectedItem.ToString(),
                            Departament = cmbDepartaments.SelectedItem.ToString()
                        };

                        db.Add(auxiliarAppointment);
                        db.SaveChanges();//Se guarda en la base de datos

                        List<Appointment> newList = db.Appointments.ToList();//Creamos otra lista pero actualizada
                         var auxiliarID = newList.Where(u => u.Date == appointmentDate && u.Hour == appointmentHour).ToList();//Buscamos el id de la cita que creamos anteriormente para asociarlo con la variable de citizen

                        var auxCitizen = new Citizen()
                        {//Ingresamos los datos del citizen
                            Dui = auxiliarDuiNumber,
                            Name = txtInsertName.Text + " " + txtInsertLastNames.Text,
                            Mail = txtInsertEmail.Text,
                            City = cmbCity.SelectedItem.ToString(),
                            Departament = cmbDepartaments.SelectedItem.ToString(),
                            Phone = auxiliarPhoneNumber,
                            Age = auxiliarAge,
                            //AssociateNumber = int.Parse(txtInsertGobNumber.Text),
                            AppointmentId = auxiliarID[0].Code,
                            //GobInstitutionId = int.Parse(cmbGobInstitution.SelectedIndex.ToString())                           
                        };

                        List<Citizen> verifyCitizen = db.Citizens.ToList();//Creamos una list acon los ciudadanos actuales en el programa
                        var checkCitizen = verifyCitizen.Where(u => u.Name.ToLower().CompareTo(auxCitizen.Name.ToLower()) == 0).ToList().Count() > 0;//Si existe o no el ciudadano
                        if(!checkCitizen)//si no existe
                        {//Agregamos la variable a la base de datos y reniciamos las variables de los compnentes del form
   
                            if (auxCitizen.Age < 60 && auxCitizen.GobInstitutionId == null && auxCitizen.AssociateNumber == null)
                            {
                                db.Remove(auxiliarAppointment);//Removemos el appointment y guardamos los cambios
                                db.SaveChanges();
                                MessageBox.Show("¡Usted no pertenece a ningun grupo de riesgo!", "Ministerio de Salud de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                AppointmentSystem_StartVars();
                            }
                            else
                            {
                                db.Add(auxCitizen);
                                db.SaveChanges();
                                MessageBox.Show("¡Su cita fue agregada correctamente!", "Ministerio de Salud de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AppointmentSystem_StartVars();
                            }
                        }
                        else
                        {//Si existe 
                            db.Remove(auxiliarAppointment);//Removemos el appointment y guardamos los cambios
                            db.SaveChanges();
                            MessageBox.Show("¡Esta persona ya tiene una cita asignada!", "Ministerio de Salud de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Error);//Se muestra un mensaje al usuario
                            AppointmentSystem_StartVars();//Se reinician los componentes del form
                        }
                    }
                    catch (Exception f) 
                    {
                        MessageBox.Show(f.Message);//Si se da un error (Para testeo)
                        //MessageBox.Show("Ocurrio un error al usar la base de datos", "Minsterio de Salud de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    lblGeneralWarningTwo.Visible = true;//Si los caracteres de los textbox contienen simbolos, se general un error que hace visibles los label de advertencias
                }
                lblGeneralWarning.Visible = false;
            }
            catch
            {
                lblGeneralWarning.Visible = true;
            }
        }

        private void AppointmentSystem_StartVars()
        {//Iniciar todas las varibales de los componentes de los forms en null y recargar datasources
            lblGeneralWarning.Visible = false;
            lblGeneralWarningTwo.Visible = false;
            txtMedicalRecord.Text = null;
            txtInsertName.Text = null;
            txtInsertLastNames.Text = null;
            txtInsertEmail.Text = null;
            txtInsertPhoneNumer.Text = null;
            txtInsertDUI.Text = null;
            txtInsertGobNumber.Text = null;
            var db = new covidcontext();
            List<GobInstitution> gobInstList = db.GobInstitutions.ToList();
            cmbGobInstitution.DataSource = null;
            cmbGobInstitution.DataSource = gobInstList;
            cmbGobInstitution.ValueMember = "Code";
            cmbGobInstitution.DisplayMember = "Institution";
            dgvToShowAppointments.DataSource = null;
            dgvToShowAppointments.DataSource = PopulateDataGridView();
            dgvToShowAppointments.Columns[0].HeaderText = "ID CITA";
            dgvToShowAppointments.Columns[1].HeaderText = "NOMBRE";
            dgvToShowAppointments.Columns[2].HeaderText = "DUI";
            dgvToShowAppointments.Columns[3].HeaderText = "EDAD";
            dgvToShowAppointments.Columns[4].HeaderText = "FECHA";
            dgvToShowAppointments.Columns[5].HeaderText = "HORA";
            dgvToShowAppointments.Columns[6].HeaderText = "DOSIS";
        }

        private void cmbDepartaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Departament(cmbDepartaments.SelectedIndex);//Cuando el valor del combobox de departamentos cambie
        }
        private void Selected_Departament(int auxiliarIndex)
        {//Elije el caso de departamento y acopla los municipios a ese caso de departamento
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

        public List<toDataGridView> PopulateDataGridView()
        {
            List<toDataGridView> toPopulate = new List<toDataGridView>();
            var db = new covidcontext();
            List<Citizen> toListCitizen = db.Citizens.ToList();

            toListCitizen.ForEach(u =>
            {
                List<Appointment> toListAppontment = db.Appointments.ToList();
                var auxStruct = new toDataGridView();

                auxStruct.appointmentDgvID = u.AppointmentId;
                auxStruct.appointmentDgvName = u.Name;
                auxStruct.appointmentDgvDui = u.Dui;
                auxStruct.appointmentDgvAge = u.Age;
                auxStruct.appointmentDgvDate = u.Appointment.Date;
                auxStruct.appointmentDgvTime = u.Appointment.Hour;
                auxStruct.appointmentDgvDose = u.Appointment.Dose;
                toPopulate.Add(auxStruct);
            });
            return toPopulate;
        }
    }
}