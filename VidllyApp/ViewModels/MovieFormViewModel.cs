using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidllyApp.Models;

namespace VidllyApp.ViewModels
{
    public class MovieFormViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}