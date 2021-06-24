using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class Citizenxsickness
    {
        public int Code { get; set; }
        public int? CitizenDui { get; set; }
        public int? SicknessCode { get; set; }

        public virtual Citizen CitizenDuiNavigation { get; set; }
        public virtual Sickness SicknessCodeNavigation { get; set; }
    }
}
