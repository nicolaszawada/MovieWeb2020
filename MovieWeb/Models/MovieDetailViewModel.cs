using System;
using System.Collections;
using System.Collections.Generic;

namespace MovieWeb.Models
{
    public class MovieDetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
        public string WatchStatus { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
