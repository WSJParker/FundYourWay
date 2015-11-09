using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace FundYourWay.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Transaction
    {
       [Key]
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public int TransactionId { get; set; }
       
       [Required]
       public int amount { get; set; }
        [ForeignKey("Funder")]
        public int? FunderId { get; set; }
        public virtual UserProfile Funder { get; set; }

       [ForeignKey("Project")]
       public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}