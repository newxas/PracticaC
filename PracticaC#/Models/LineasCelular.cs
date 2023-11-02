using System.ComponentModel.DataAnnotations;

namespace PracticaC_.Models
{
    public class LineasCelular
    {
        [Key]
        public int MobileLineId { get; set; }
        public Int64 MobileLine { get; set; } = 0;
        public string Description { get; set; } = string.Empty;

    }

}
