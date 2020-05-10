using MeraClient2.Coms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public interface IDataInput
    {
        void GetTextFromSourceAndSendRequest(IComService comService);
    }
}
