using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class Appointment
    {
        public Appointment()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Dose { get; set; }
        public int EmployeeCode { get; set; }

        public virtual Employee EmployeeCodeNavigation { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
