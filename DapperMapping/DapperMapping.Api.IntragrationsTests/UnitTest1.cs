using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;
using DapperMapping.Api.Models;
using System.Collections.Generic;

namespace DapperMapping.Api.IntragrationsTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync("/WeatherForecast");
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            var Contacts = JsonConvert.DeserializeObject<IEnumerable<Contacts>>(stringResult);
            Assert.NotEmpty(Contacts);
        }
    }
}