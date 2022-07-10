using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DalObject
{
    public partial class DalObject
    {
        public int AddDevice(DeviceType type, int range, float fieldOfVision)
        {
            int id = DataSource.idIntilizer;
            try
            {
                DataSource.devices.Add(new ObservationDevice(id, type, range, fieldOfVision));
            }
            catch (FieldAccessException)
            {
                throw;
            }
            catch (RankException)
            {
                throw;
            }
            
            DataSource.idIntilizer++;
            return id;
        }

        public IEnumerable<ObservationDevice> GetDevices(Predicate<ObservationDevice> getBy = null)
        {
            getBy ??= (device => true);
            return (from device in DataSource.devices
                    where getBy(device)
                    select device);
        }

        public void RemoveDevice(int id)
        {
            ObservationDevice device = DataSource.devices.Find(device => device.Id == id);
            bool success = DataSource.devices.Remove(device);
            if (!success) throw new KeyNotFoundException();

        }


    }
}
