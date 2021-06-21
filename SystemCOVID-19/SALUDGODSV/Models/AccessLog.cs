using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class AccessLog
    {
        public AccessLog()
        {
            Employees = new HashSet<Employee>();
        }

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
