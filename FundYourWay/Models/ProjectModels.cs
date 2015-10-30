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

        public DateTime OpenForFundingDateAndTime { get; set; }

        public DateTime CloseForFundingDateAndTime { get; set; }

        public Boolean IsApproved { get; set; }

        public Boolean IsDeleted { get; set; }

        public int limitedFundingAmount { get; set; }

        public int CurrentFundingAmount { get; set; }
        //[ForeignKey("ProjectOwner")]
        //public int ProjectOwerId { get; set; }

        //[ForeignKey("ProjectCompany")]
        //public int? ProjectCompanyId { get; set; }

        public ICollection<UserProfile> FundingUsers { get; set; }

    }
}