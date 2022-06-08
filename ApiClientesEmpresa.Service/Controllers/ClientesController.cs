using ApiClientesEmpresa.Infra.Data.Entities;
using ApiClientesEmpresa.Infra.Data.Interfaces;
using ApiClientesEmpresa.Service.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientesEmpresa.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public IActionResult Post(ClientePostRequest request)
        {
            try
            {
                var cliente = new Cliente();
                {
                    cliente.IdCliente = Guid.NewGuid();
                    cliente.Nome = request.Nome;
                    cliente.Email = request.Email;
                    cliente.Cpf = request.Cpf;
                    cliente.DataNascimento = request.DataNascimento;
                }
                var Tcliente = _clienteRepository.GetByEmail(cliente.Email);
                if (Tcliente == null)
                {
                    if (DateTime.Now.Year -  request.DataNascimento.Year < 18)
                    {
                        return StatusCode(400, new { message = "Data nascimento inferior a 18 anos.", cliente });

                    }
                    _clienteRepository.Create(cliente);
                    return StatusCode(201, new { message = "Cliente cadastrado com sucesso.", cliente });
                }else
                {
                    return StatusCode(400, new { message = "email duplicado.", cliente });

                }
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePostRequest request)
        {
            try
            {
                #region Buscando o cliente no banco de dados através do ID

                var cliente = _clienteRepository.GetById(request.IdCliente);
                if (cliente == null)
                    //HTTP 422 (UNPROCESSABLE ENTITY)
                    return StatusCode(422,new { message = "Cliente não encontrado ou inválido para edição." });

                #endregion

                #region Atualizando o cliente
                cliente.Nome = request.Nome;
                cliente.Cpf = request.Cpf;

                _clienteRepository.Update(cliente);

                return StatusCode(200,new { message = "Cliente atualizado com sucesso", cliente });

                #endregion
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente)
        {
            try
            {
                #region Buscando o cliente no banco de dados através do ID

                var cliente = _clienteRepository.GetById(idCliente);
                if (cliente == null)
                    //HTTP 422 (UNPROCESSABLE ENTITY)
                    return StatusCode(422, new { message = "Cliente não encontrado ou inválido para edição." });

                #endregion

                #region Atualizando o cliente

                _clienteRepository.Delete(cliente);

                return StatusCode(200, new { message = "Cliente atualizado com sucesso", cliente });

                #endregion
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _clienteRepository.GetAll();

                //HTTP 200 (OK)
                return StatusCode(200, clientes);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(Guid idCliente)
        {
            try
            {
                var clientes = _clienteRepository.GetById(idCliente);

                //HTTP 200 (OK)
                return StatusCode(200, clientes);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

    }
}
