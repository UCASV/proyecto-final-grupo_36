using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class AccessLog
    {
        public AccessLog()
        {
            Managers = new HashSet<Manager>();
        }

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}
