using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class Appointment
    {
        public Appointment()
        {
            Managers = new HashSet<Manager>();
        }

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Dose { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
