using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class GobInstitution
    {
        public GobInstitution()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Code { get; set; }
        public string Institution { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
