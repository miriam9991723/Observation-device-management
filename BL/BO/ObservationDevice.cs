using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ObservationDevice : Entities.ObservationDevice
    {
        public ObservationDevice(int id, DeviceType type, int range, float fieldOfVision) : base(id, (Entities.DeviceType)type, range, fieldOfVision) { }
    }
}
