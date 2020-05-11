using MeraClient2.Coms;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class DataInputContext
    {
        private IDataInput DataInput;

        public DataInputContext(IDataInput dataInput)
        {
            DataInput = dataInput;
        }

        public void SetStrategy(IDataInput dataInput)
        {
            DataInput = dataInput;
        }

        public async Task RunSelectedDataInput(IComService comService)
        {
            await DataInput.GetTextFromSourceAndSendRequest(comService);
        }
    }
}
