using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Sickness
    {
        public Sickness()
        {
            Citizenxsicknesses = new HashSet<Citizenxsickness>();
        }

        public int Code { get; set; }
        public string Sickness1 { get; set; }

        public virtual ICollection<Citizenxsickness> Citizenxsicknesses { get; set; }
    }
}
