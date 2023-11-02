using System.ComponentModel.DataAnnotations;

namespace PracticaC_.Models
{
    public class DetalleLlamadas
    {
        [Key]
        public int CallDetailId { get; set; }

        public Int64 MobileLine { get; set; } = 0;

        public Int64 CalledPartyNumber { get; set; } = 0;

        public string CalledPartyDescription { get; set; } = string.Empty;

        public string DateTime { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string TotalCost { get; set; } = string.Empty;


    }
}
