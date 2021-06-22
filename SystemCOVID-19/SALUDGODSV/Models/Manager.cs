using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Manager
    {
        public int Code { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int CodeEmployee { get; set; }
        public int CodeCabin { get; set; }

        public virtual Cabin CodeCabinNavigation { get; set; }
        public virtual Employee CodeEmployeeNavigation { get; set; }
    }
}
