using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class SecondaryEffect
    {
        public SecondaryEffect()
        {
            CitizenxsecondaryEffects = new HashSet<CitizenxsecondaryEffect>();
        }

        public int Code { get; set; }
        public string SecondaryEffect1 { get; set; }

        public virtual ICollection<CitizenxsecondaryEffect> CitizenxsecondaryEffects { get; set; }
    }
}
