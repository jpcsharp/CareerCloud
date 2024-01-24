using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco:IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Company_Name")]
        public string? CompanyName { get; set; }

        [Column("Company_Description")]
        public string? CompanyDescription { get; set; }

        [Column("Time_Stamp")]
        [Timestamp]
        public byte[]? TimeStamp { get; set; }
        [Column("Company")]
        public Guid Company { get; set; }
        public string? LanguageId { get; set; }
        [NotMapped]
        public virtual ICollection<CompanyProfilePoco> CompanyProfile { get; set; }
        [NotMapped]
        public virtual ICollection<SystemLanguageCodePoco> SystemLanguageCode { get; set; }
        [NotMapped]
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    }
}
