using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.Coms
{
    class ComServiceFactory
    {
        public static IComService GetComService(string commServer)
        {
            IComService comService = null;
            if(commServer == "mera")
            {
                comService = new MeraServerComService();
            }

            return comService;
        }

        
    }
}
