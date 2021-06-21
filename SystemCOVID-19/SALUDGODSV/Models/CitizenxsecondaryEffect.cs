using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class CitizenxsecondaryEffect
    {
        public int Code { get; set; }
        public int? CitizenDui { get; set; }
        public int? SecondaryeffectCode { get; set; }

        public virtual Citizen CitizenDuiNavigation { get; set; }
        public virtual SecondaryEffect SecondaryeffectCodeNavigation { get; set; }
    }
}
