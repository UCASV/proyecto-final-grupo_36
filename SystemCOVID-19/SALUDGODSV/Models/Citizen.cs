using System;
using System.Collections.Generic;

#nullable disable

namespace SALUDGODSV.Models
{
    public partial class Citizen
    {
        public Citizen()
        {
            CitizenxsecondaryEffects = new HashSet<CitizenxsecondaryEffect>();
            Citizenxsicknesses = new HashSet<Citizenxsickness>();
        }

        public int Dui { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Departament { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public int? AssociateNumber { get; set; }
        public int? GobInstitutionId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual GobInstitution GobInstitution { get; set; }
        public virtual ICollection<CitizenxsecondaryEffect> CitizenxsecondaryEffects { get; set; }
        public virtual ICollection<Citizenxsickness> Citizenxsicknesses { get; set; }
    }
}
