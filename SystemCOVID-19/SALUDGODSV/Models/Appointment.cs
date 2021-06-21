using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Citizens = new HashSet<Citizen>();
            Employees = new HashSet<Employee>();
        }

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Dose { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
