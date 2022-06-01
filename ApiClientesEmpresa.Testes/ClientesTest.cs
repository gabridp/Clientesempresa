using ApiClientesEmpresa.Infra.Data.Entities;
using ApiClientesEmpresa.Service.Requests;
using ApiClientesEmpresa.Test.Config;
using ApiEstoque.Tests.Config;
using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiClientesEmpresa.Test
{
    public class ClientesTest
    {
        private readonly string _endpoint;
        private readonly string _accessToken;

        public ClientesTest()
        {
            _endpoint = ApiConfig.GetEndpoint() + "/clientes";

            var authenticationConfig = new AuthenticationConfig();
            _accessToken = authenticationConfig.ObterTokenAcesso().Result;
        }


        [Fact]
        public async Task<ClienteResult> Test_Post_Returns_Ok()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await httpClient.PostAsync(_endpoint, CreateClienteData());

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var result = JsonConvert.DeserializeObject<ClienteResult>
               (response.Content.ReadAsStringAsync().Result);

            return result;
        }

        [Fact]
        public async Task Test_Put_Returns_Ok()
        {
            var result = await Test_Post_Returns_Ok();

            var faker = new Faker("pt_BR");

            //criando os dados para editar o estoque
            var request = new ClientePostRequest
            {
                IdCliente = result.cliente.IdCliente,
                Nome = faker.Person.FullName,
                Email = faker.Person.Email
            };

            var httpClient = new HttpClient();

            var content = new StringContent
                (JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await httpClient.PutAsync(_endpoint, content);

            response
               .StatusCode
               .Should()
               .Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Test_Delete_Returns_Ok()
        {
            var result = await Test_Post_Returns_Ok();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization   = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await httpClient.DeleteAsync(_endpoint   + "/" + result.cliente.IdCliente);

            response
               .StatusCode
               .Should()
               .Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Test_GetAll_Returns_Ok()
        {
            await Test_Post_Returns_Ok();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization  = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await httpClient.GetAsync(_endpoint);

            var result = JsonConvert.DeserializeObject<List<Cliente>>(response.Content.ReadAsStringAsync().Result);

            result.
                Should()
                .NotBeNullOrEmpty();

        }

        [Fact]
        public async Task Test_GetById_Returns_Ok()
        {
            var result = await Test_Post_Returns_Ok();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await httpClient.GetAsync(_endpoint + "/" + result.cliente.IdCliente);

            var resposta = JsonConvert.DeserializeObject<Cliente>(response.Content.ReadAsStringAsync().Result);

            resposta
                .Should()
                .NotBeNull();

        }
        private StringContent CreateClienteData()
        {
            var faker = new Faker("pt_BR");

            var request = new ClientePostRequest()
            {
                Nome = faker.Person.FullName,
                Cpf = "07240884740",
                Email = faker.Person.Email,
                DataNascimento = faker.Person.DateOfBirth
            };

            return new StringContent
                (JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }
    }
    /// <summary>
    /// Classe para capturar o retorno do resultado dos testes POST, PUT ou DELETE
    /// </summary>
    public class ClienteResult
    {
        public string message { get; set; }
        public Cliente cliente { get; set; }
    }

}