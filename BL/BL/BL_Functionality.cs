using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BL
{
    partial class BL
    {
        public int AddDevice(DeviceType type, int range, float fieldOfVision)
        {
            return dal.AddDevice((Entities.DeviceType)type, range, fieldOfVision);
        }

        public IEnumerable<ObservationDevice> GetAllDevices()
        {
            return from device in dal.GetDevices()
                   select convertToBl(device);
        }

        public IEnumerable<ObservationDevice> GetDevicesOfSpecificType(DeviceType type)
        {
            return from device in dal.GetDevices(device => device.Type == (Entities.DeviceType)type)
                   select convertToBl(device);
        }

        public IEnumerable<ObservationDevice> GetDevicesSortedByRange()
        {
            return from device in dal.GetDevices()
                   orderby (device.Range)
                   select convertToBl(device);
        }

        //returns device with the farthest range, which allows a minimum field of view and above 
        public IEnumerable<ObservationDevice> GetHighestRangeWithMinimalfieldOfVision(float min)
        {
            return from device in dal.GetDevices(device => device.FieldOfVision >= min)
                   where device.Range == dal.GetDevices(device => device.FieldOfVision >= min).Max(d => d.Range)
                   select convertToBl(device);
        }

        public void RemoveDevice(int id)
        {
            try
            {
                dal.RemoveDevice(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }

        }

        private BO.ObservationDevice convertToBl(Entities.ObservationDevice device)
        {
            return  new BO.ObservationDevice(id: device.Id, type: (BO.DeviceType)device.Type, range: device.Range, fieldOfVision:device.FieldOfVision);
        }
    }
}
