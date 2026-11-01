using System.ComponentModel.DataAnnotations;

namespace SollicitatieTracker.Models
{
    public class Sollicitatie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Bedrijfsnaam { get; set; }

        [Required]
        [MaxLength(150)]
        public string Functietitel { get; set; }

        [EnumDataType(typeof(SollicitatieStatus))]
        public SollicitatieStatus Status { get; set; }

        public DateOnly Datum { get; set; }

        [MaxLength(1000)]
        public string Notities { get; set; }
    }
}