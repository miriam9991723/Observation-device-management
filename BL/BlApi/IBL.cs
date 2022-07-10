using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface IBL
    {
        int AddDevice(DeviceType deviceType, int range, float fielsOfVision);
        void RemoveDevice(int id);
        IEnumerable<ObservationDevice> GetAllDevices();
        IEnumerable<ObservationDevice> GetDevicesSortedByRange();
        IEnumerable<ObservationDevice> GetDevicesOfSpecificType(DeviceType type);
        IEnumerable<ObservationDevice> GetHighestRangeWithMinimalfieldOfVision(float min);
    }
}
