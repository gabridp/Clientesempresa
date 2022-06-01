using System.ComponentModel.DataAnnotations;

namespace ApiClientesEmpresa.Service.Requests
{
    public class LoginPostRequest
    {
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Mínimo de {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Máximo de {1} caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Senha { get; set; }
    }
}
