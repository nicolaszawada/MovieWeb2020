using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Models
{
    public class MovieCreateViewModel
    {
        [DisplayName("Titel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Titel is verplicht!")]
        [MaxLength(20, ErrorMessage = "Maximum 20 karakters!")]
        public string Title { get; set; }

        [DisplayName("Omschrijving")]
        public string Description { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        [DisplayName("Release datum")]
        [Range(typeof(DateTime), "01/01/2000", "01/01/2030", ErrorMessage = "Datum moet tussen...")]
        public DateTime ReleaseDate { get; set; }

        public IFormFile Photo { get; set; }

        public List<SelectListItem> WatchStatuses { get; set; } = new List<SelectListItem>();

        public int SelectedWatchStatus { get; set; }
    }
}
