using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Heroku.NET.Apps;
using Heroku.NET.Connections;
using Moq;
using Xunit;

namespace Heroku.NET.Tests.Apps
{
    public class AppsClientTests
    {
        private Mock<IConnection> _mockConnection;

        public AppsClientTests()
        {
            _mockConnection = new Mock<IConnection>();
        }

        [Fact]
        public async Task GetAllRequestsAList()
        {
            _mockConnection
                .Setup(c => c.Get<ReadOnlyCollection<App>>("/apps"))
                .ReturnsAsync(() => new ReadOnlyCollection<App>(new List<App>()));

            await new AppsClient(_mockConnection.Object).GetAll();

            _mockConnection.Verify(c => c.Get<ReadOnlyCollection<App>>("/apps"));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetByIdSendsTheCorrectRequest()
        {
            var id = new Guid();
            _mockConnection.SetReturnsDefault(new App());

            await new AppsClient(_mockConnection.Object).Get(id);

            _mockConnection.Verify(c => c.Get<App>($"/apps/{id}"));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetByNameSendsTheCorrectRequest()
        {
            var name = "mycompany-myapp";
            _mockConnection.SetReturnsDefault(new App());

            await new AppsClient(_mockConnection.Object).Get(name);

            _mockConnection.Verify(c => c.Get<App>($"/apps/{name}"));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CreateAppSendsTheCorrectRequest()
        {
            var app = MockApp.Create();
            _mockConnection.SetReturnsDefault(app);

            await new AppsClient(_mockConnection.Object).Create(app);

            _mockConnection.Verify(c => c.Post<App, App>($"/apps", app));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task PatchAppSendsTheCorrectRequest()
        {
            var app = MockApp.Create();
            _mockConnection.SetReturnsDefault(app);

            await new AppsClient(_mockConnection.Object).Update(app);

            _mockConnection.Verify(c => c.Patch<App, AppUpdate>($"/apps/{app.Id}", It.IsAny<AppUpdate>()));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task EnableACMSendsTheCorrectRequest()
        {
            var app = MockApp.Create();
            _mockConnection.SetReturnsDefault(app);

            await new AppsClient(_mockConnection.Object).EnableACM(app);

            _mockConnection.Verify(c => c.Post<App, object>($"/apps/{app.Id}/acm", null));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisableACMSendsTheCorrectRequest()
        {
            var app = MockApp.Create();
            _mockConnection.SetReturnsDefault(app);

            await new AppsClient(_mockConnection.Object).DisableACM(app);

            _mockConnection.Verify(c => c.Delete<App>($"/apps/{app.Id}/acm"));
            _mockConnection.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task RefreshACMSendsTheCorrectRequest()
        {
            var app = MockApp.Create();
            _mockConnection.SetReturnsDefault(app);

            await new AppsClient(_mockConnection.Object).RefreshACM(app);

            _mockConnection.Verify(c => c.Patch<App, object>($"/apps/{app.Id}/acm", null));
            _mockConnection.VerifyNoOtherCalls();
        }
    }
}
