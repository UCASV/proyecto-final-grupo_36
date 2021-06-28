using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AccessLogs = new HashSet<AccessLog>();
            Appointments = new HashSet<Appointment>();
        }

        public int Code { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Occupation { get; set; }
        public int ManagerCode { get; set; }
        public string SecurityAnswer { get; set; }
        public int CodeSecurityQuestion { get; set; }

        public virtual SecurityQuestion CodeSecurityQuestionNavigation { get; set; }
        public virtual Manager ManagerCodeNavigation { get; set; }
        public virtual ICollection<AccessLog> AccessLogs { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
