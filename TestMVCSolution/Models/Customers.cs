using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVCSolution.Models
{
    public class Customers
    {
        public Int32 Id { get; set; } 

        [Required]
        [StringLength(255)]
        public String CustomerName { get; set; }

        public bool IsSubscibedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public MembeshipType MembeshipType { get; set; }

        [Display(Name = "Membership Types")]
        public byte MembeshipTypeId { get; set; }
    }
}