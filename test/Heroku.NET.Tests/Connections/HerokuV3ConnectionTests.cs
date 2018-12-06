using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Heroku.NET.Apps;
using Heroku.NET.Connections;
using Heroku.NET.Tests.Apps;
using Moq;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;
using Xunit;

namespace Heroku.NET.Tests.Connections
{
    public class HerokuV3ConnectionTests : IDisposable
    {
        private FluentMockServer _server;


        public HerokuV3ConnectionTests()
        {
            this._server = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://localhost:9095" }
            });
        }

        public void Dispose()
        {
            this._server.Stop();
        }

        [Fact]
        public async Task TestGetRequestGeneration()
        {
            var connection = new HerokuV3Connection(new HttpClient(), "http://localhost:9095");

            this._server
                .Given(
                    Request.Create()
                        .WithPath("/apps/1234")
                        .UsingGet()
                        .WithHeader("User-Agent", new RegexMatcher(@"^Heroku\.NET/(\d+\.?){4}$"))
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody(HerokuV3ConnectionFixtures.ExampleApp, "String", Encoding.UTF8)
                );

            var obj = await connection.Get<App>("/apps/1234");
            Assert.Equal("example", obj.Name);
        }

        [Fact]
        public async Task TestPostRequestGeneration()
        {
            var connection = new HerokuV3Connection(new HttpClient(), "http://localhost:9095");

            this._server
                .Given(
                    Request.Create()
                        .WithPath("/apps")
                        .WithHeader("User-Agent", new RegexMatcher(@"^Heroku\.NET/(\d+\.?){4}$"))
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(201)
                        .WithBody(HerokuV3ConnectionFixtures.ExampleApp, "String", Encoding.UTF8)
                );

            var obj = await connection.Post<App, App>("/apps", MockApp.Create());
            Assert.Equal("example", obj.Name);
        }

        private HttpRequestMessage BuildTestRequestMessage()
        {
            var version = typeof(HerokuV3Connection)
                .Assembly
                .GetName()
                .Version;

            var message = new HttpRequestMessage
            {
                RequestUri = new Uri("https://api.heroku.com/apps/1234"),
                Method = HttpMethod.Get,
            };

            message.Headers.Add("Accept", "application/vnd.heroku+json; version=3");
            message.Headers.Add("User-Agent", $"Heroku.NET/{version}");

            return message;
        }
    }
}
