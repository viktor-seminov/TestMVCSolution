﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMVCSolution.Models
{
    public class MembeshipType
    {
        public byte Id { get; set; }
        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}