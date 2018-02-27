using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVCSolution.Models;

namespace TestMVCSolution.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customers Customers { get; set; }
        public IEnumerable<MembeshipType> MembershipTypes { get; set; }
    }
}