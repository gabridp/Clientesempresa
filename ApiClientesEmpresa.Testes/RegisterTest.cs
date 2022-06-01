using ApiClientesEmpresa.Service.Requests;
using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ApiClientesEmpresa.Test
{

    public class RegisterTest
    {
        private readonly string _endpoint;

        public RegisterTest()
        {
            _endpoint = "http://apiprojetofinal-001-site1.btempurl.com/api/register";
        }

        [Fact]
        public async Task Test_Post_Returns_Created()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync (_endpoint, CreateUserData());
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Test_Post_Returns_UnprocessableEntity()
        {
            var httpClient = new HttpClient();
            var content = CreateUserData();

            //cadastrando um usuário na API
            await httpClient.PostAsync(_endpoint, content);
            //cadastrando o mesmo usuário novamente
            var response = await httpClient.PostAsync(_endpoint, content);

            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.UnprocessableEntity);
        }

        //método para gerar os dados do teste
        private StringContent CreateUserData()
        {
            var faker = new Faker("pt_BR");

            var request = new RegisterPostRequest()
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Senha = faker.Internet.Password()
            };

            return new StringContent
                (JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json");
        }
    }
}
