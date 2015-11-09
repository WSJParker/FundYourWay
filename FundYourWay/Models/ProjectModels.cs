using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundYourWay.Models
{
    public class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public int CurrentFundingAmount { get; set; }
        [ForeignKey("ProjectOwner")]
        public int ProjectOwerId { get; set; }
        public virtual UserProfile ProjectOwner { get; set; }
        //[ForeignKey("ProjectCompany")]
        //public int? ProjectCompanyId { get; set; }

        public virtual ICollection<UserProfile> FundingUsers { get; set; }

    }
}