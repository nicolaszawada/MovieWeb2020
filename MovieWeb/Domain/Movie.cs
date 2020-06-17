using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
        public WatchStatus WatchStatus { get; set; }
        public int WatchStatusId { get; set; }
        public ICollection<MovieTag> MovieTags { get; set; }
    }
}
