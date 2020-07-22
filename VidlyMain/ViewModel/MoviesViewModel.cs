using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMain.Models;

namespace VidlyMain.ViewModel
{
    public class MoviesViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public Movies Movies { get; set; }

    }
}