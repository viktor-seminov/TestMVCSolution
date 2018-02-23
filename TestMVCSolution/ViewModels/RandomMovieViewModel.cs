using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVCSolution.Models;


namespace TestMVCSolution.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movies { get; set; }
        public List<Customers> Customers { get; set; }
    }
}