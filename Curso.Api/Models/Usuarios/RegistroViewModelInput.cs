using System.ComponentModel.DataAnnotations;

namespace Curso.Api.Models.Usuarios
{

    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }
    }
}
