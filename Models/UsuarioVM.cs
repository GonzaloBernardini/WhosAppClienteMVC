using System.ComponentModel.DataAnnotations;

namespace WhosAppMVCfront.Models
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "Nombre de usuario Obligatorio")]
        [StringLength(20)]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El mail es obligatorio")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El email no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
    }
}
