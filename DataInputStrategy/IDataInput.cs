using MeraClient2.Coms;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public interface IDataInput
    {
        Task GetTextFromSourceAndSendRequest(IComService comService);
    }
}
