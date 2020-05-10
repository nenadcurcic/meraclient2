using MeraClient2.Coms;

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

        public void RunSelectedDataInput(IComService comService)
        {
            DataInput.GetTextFromSourceAndSendRequest(comService);
        }
    }
}
