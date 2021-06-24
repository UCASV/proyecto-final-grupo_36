using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV
{
    public partial class SecurityQuestion
    {
        public SecurityQuestion()
        {
            Employees = new HashSet<Employee>();
        }

        public int Code { get; set; }
        public string SecurityQuestion1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
