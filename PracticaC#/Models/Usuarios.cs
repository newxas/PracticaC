using System.ComponentModel.DataAnnotations;

namespace PracticaC_.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Pasword { get; set; } = string.Empty;
        public string TipoUsuario { get; set;} = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

    }
}
