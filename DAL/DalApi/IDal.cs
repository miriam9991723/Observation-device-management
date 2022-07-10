using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DalApi
{
    public interface IDal
    {
        int AddDevice(DeviceType type, int range, float fieldOfVision);
        void RemoveDevice(int id);
        IEnumerable<ObservationDevice> GetDevices(Predicate<ObservationDevice> getBy = null);
    }
}
