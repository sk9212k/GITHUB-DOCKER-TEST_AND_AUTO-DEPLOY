using FluentAssertions;
using System;
using System.Net;
using System.Net.Http;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using github_docker_deploy.Controllers;

namespace github_docker_deploy_test
{
    public class UnitTest1
    {
      
        [Fact]
        public async System.Threading.Tasks.Task Test_GetAsync()
        {
            using (var client = new TestClientProvider().Client)
            {

                var response = await client.GetAsync("/api/Data");

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Should().NotBeNull();
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_PostAsync()
        {
            using (var client = new TestClientProvider().Client)
            {

                var response = await client.PostAsync("/api/Data",new StringContent(JsonConvert.SerializeObject(new DataControllerRequest(1, 2)), Encoding.UTF8,"application/json"));
                var responseData = response.Content.ReadAsStringAsync().Result;
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                responseData.Should().Be("3");
            }
        }
    }
}
