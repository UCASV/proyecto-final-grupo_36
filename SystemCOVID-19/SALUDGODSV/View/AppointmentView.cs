using iTextSharp.text;
using iTextSharp.text.pdf;
using SALUDGODSV.Context;
using SALUDGODSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            btnVacunar.BackColor = myColor2;
            btnShowInformation.BackColor = myColor2;
            lblShowName.Text = GlobalStruct.appointmentDgvName;
            lblShowBirthday.Text = GlobalStruct.appointmentDgvAge.ToString();
            lblShowDUI.Text = GlobalStruct.appointmentDgvDui.ToString();
            lblShowDosis.Text = GlobalStruct.appointmentDgvDose;

        }

        private void btnVacunar_Click(object sender, EventArgs e)
        {

            if(GlobalStruct.appointmentDgvDose.CompareTo("2") == 0)
            {
                MessageBox.Show("Usted ya ha sido registrado con anterioridad para su segunda dosis", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
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

                Appointment toReBuild = (from aux in db.Appointments
                                         where aux.Code == GlobalStruct.appointmentDgvID
                                         select aux).First();
                toReBuild.Dose = "2";
                toReBuild.Date = appointmentDate;
                toReBuild.Hour = appointmentHour;
                db.SaveChanges();
                MessageBox.Show("Se ha registrado para su segunda dosis exitosamente.", "Ministerio de salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnShowInformation_Click(object sender, EventArgs e)
        {
            Document auxDocument = new Document();
            SaveFileDialog auxiliarSaveFileDialog = new SaveFileDialog();
            auxiliarSaveFileDialog.InitialDirectory = @"C:";
            auxiliarSaveFileDialog.Title = "Ministerio de salud";
            auxiliarSaveFileDialog.DefaultExt = "pdf";
            auxiliarSaveFileDialog.Filter = "pdf Files (.pdf)|.pdf";
            auxiliarSaveFileDialog.FilterIndex = 2;
            auxiliarSaveFileDialog.RestoreDirectory = true;

            var auxFile = "";
            if (auxiliarSaveFileDialog.ShowDialog() == DialogResult.OK)
                auxFile = auxiliarSaveFileDialog.FileName;
            if(auxFile.Trim() != "")
            {
                FileStream auxiliarFileStream = new FileStream(auxFile, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.ReadWrite);
                PdfWriter.GetInstance(auxDocument, auxiliarFileStream);
                auxDocument.Open();

                Paragraph auxTitle = new Paragraph();
                auxTitle.Font = FontFactory.GetFont(FontFactory.TIMES_ITALIC, 22f, BaseColor.CYAN);
                auxTitle.Add("MINISTERIO DE SALUD DE EL SALVADOR\nCAMPAÑA DE VACUNACION CONTRA COVID-19");
                auxDocument.Add(auxTitle);
                auxDocument.Add(new Paragraph($"Nombre: {GlobalStruct.appointmentDgvName}\nNumero DUI: {GlobalStruct.appointmentDgvDui}" +
                    $"\nID Cita: {GlobalStruct.appointmentDgvDate.ToString("dd/MM/yyyy")}\nHora: {GlobalStruct.appointmentDgvTime}"));
                auxDocument.Close();
                MessageBox.Show("¡Archivo guardado con exito!", "Ministerio de Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
