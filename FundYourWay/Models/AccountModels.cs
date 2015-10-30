using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FundYourWay.Models
{
   

    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PersonalStatement { get; set; }

        public int FundingReceivedAmount { get; set; }

        public int FundingProvidedAmount { get; set; }

        public int CreditLevel { get; set; }

        public virtual ICollection<Project> HeldProjects { get; set; }

        public virtual ICollection<Project> FundedProjects { get; set; }
    }
}