using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }
        [Column("Time_Stamp")]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        [Column("Applicant")]
        public Guid Applicant { get; set; }
        [Column("Job")]
        public Guid Job { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfile { get; set; }
        [NotMapped]
         public virtual ICollection<CompanyJobPoco> CompanyJob { get; set; }
        public virtual CompanyJobPoco CompanyJobs { get; set; }

    }
}
