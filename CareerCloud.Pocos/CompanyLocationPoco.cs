﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public  class CompanyLocationPoco:IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Country_Code")]
        public string CountryCode { get; set; }

        [Column("State_Province_Code")]
        public string? Province { get; set; } 
        
        [Column("Street_Address")] 
        public string? Street { get; set; }
        
        [Column("City_Town")]
        public string? City { get; set; }
        
        [Column("Zip_Postal_Code")]
        public string? PostalCode { get; set; }

        [Column("Time_Stamp")]
        [Timestamp]
        public byte[]? TimeStamp { get; set; }
        public Guid Company { get; set; }
        public virtual ICollection<CompanyProfilePoco> CompanyProfile { get; set; }
        [NotMapped]
        public virtual ICollection<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodeS { get; set; }
    }
}
