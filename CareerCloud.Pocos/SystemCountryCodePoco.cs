﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco

    {
        [Key]
        public string Code { get; set; }
        [Column("Name")]
        public string Name { get; set; }
       public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfilePoco { get; set; }
        
    }
}
