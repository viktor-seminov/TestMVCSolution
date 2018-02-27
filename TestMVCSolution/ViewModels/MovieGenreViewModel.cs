using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVCSolution.Models;

namespace TestMVCSolution.ViewModels
{
    public class MovieGenreViewModel
    {
        public Movies Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}