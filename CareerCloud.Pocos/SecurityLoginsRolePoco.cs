﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco:IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Time_Stamp")]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public Guid Login { get; set; }
        public Guid Role { get; set; }
        public virtual ICollection<SecurityLoginPoco> SecurityLogin { get; set; }
        public virtual ICollection<SecurityRolePoco> SecurityRole { get; set; }

    }
}
