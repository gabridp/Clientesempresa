using System.ComponentModel.DataAnnotations;

namespace ApiClientesEmpresa.Service.Requests
{
    public class ClientePostRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdCliente { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }
        
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime DataNascimento { get; set; }
    }
}
