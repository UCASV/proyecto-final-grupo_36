using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class Employee
    {
        public Employee()
        {
            Managers = new HashSet<Manager>();
        }

        public int Code { get; set; }
        public string Mail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public string Occupation { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
