using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Employees = new HashSet<Employee>();
        }

        public int Code { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int CodeCabin { get; set; }

        public virtual Cabin CodeCabinNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
