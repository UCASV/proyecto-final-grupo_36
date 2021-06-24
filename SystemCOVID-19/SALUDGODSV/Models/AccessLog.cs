using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class AccessLog
    {
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public int EmployeeCode { get; set; }

        public virtual Employee EmployeeCodeNavigation { get; set; }
    }
}
