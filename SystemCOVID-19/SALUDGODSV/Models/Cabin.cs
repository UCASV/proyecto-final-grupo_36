using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class Cabin
    {
        public Cabin()
        {
            Managers = new HashSet<Manager>();
        }

        public int Code { get; set; }
        public int Phone { get; set; }
        public string Caretaker { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
