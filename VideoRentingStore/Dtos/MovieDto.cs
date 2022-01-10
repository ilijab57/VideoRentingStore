using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoRentingStore.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

        [Required]
        [ForeignKey("Genre")]
        public byte GenreId { get; set; }

    }
}