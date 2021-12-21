using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyClassLib.Model;

namespace PharmacyClassLib.Service.Interface
{
    public interface IChannelsForCommunication
    {
        void CreateAllChannels();
        void CreateChannelsForHospital(RegisteredHospital hospital);
    }
}
