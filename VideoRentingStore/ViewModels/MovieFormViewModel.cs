using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentingStore.Models;

namespace VideoRentingStore.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set;  }
        public Movie Movie { get; set; }
    }
}