using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaTown.Models;

namespace CinemaTown.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreTypes { get; set; }

        public Movie Movie { get; set; }
    }
}