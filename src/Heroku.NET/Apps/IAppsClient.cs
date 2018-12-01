using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Heroku.NET.Apps
{
    public interface IAppsClient
    {
        Task<ReadOnlyCollection<App>> GetAll();
    }
}
