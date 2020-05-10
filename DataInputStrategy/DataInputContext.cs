using MeraClient2.Coms;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class DataInputContext
    {
        private IDataInput DataInput;

        public DataInputContext(IDataInput dataInput)
        {
            this.DataInput = dataInput;
        }

        public void SetStrategy(IDataInput dataInput)
        {
            this.DataInput = dataInput;
        }

        public async Task RunSelectedDataInput(IComService comService)
        {
            await DataInput.GetTextFromSourceAndSendRequest(comService);
        }
    }
}
