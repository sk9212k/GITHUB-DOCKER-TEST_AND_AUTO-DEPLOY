using github_docker_auto_deploy_test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace github_docker_auto_deploy_test_TestProject
{
    public class TestClientProvider
    {
        private TestServer _server;
        public HttpClient Client { get; set; }
        public TestClientProvider()
        {
            _server=new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client=_server.CreateClient();
        }
        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
        }
    }
}
