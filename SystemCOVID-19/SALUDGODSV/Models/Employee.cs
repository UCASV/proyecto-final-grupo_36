using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Managers = new HashSet<Manager>();
        }

        public int Code { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Occupation { get; set; }
        public int CodeAppointment { get; set; }
        public int CodeAccesslog { get; set; }
        public int CodeSecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public virtual AccessLog CodeAccesslogNavigation { get; set; }
        public virtual Appointment CodeAppointmentNavigation { get; set; }
        public virtual SecurityQuestion CodeSecurityQuestionNavigation { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
