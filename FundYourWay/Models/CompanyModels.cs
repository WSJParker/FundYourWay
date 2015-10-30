using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FundYourWay.Models
{
    public class Company
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        //[ForeignKey("CompanyOwner")]
        //public int CompanyOwnerId { get; set; }

        public ICollection<UserProfile> Managers { get; set; }

        public ICollection<Project> HoldingProjects { get; set; }
    }
}