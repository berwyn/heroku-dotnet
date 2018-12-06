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
    }
}
