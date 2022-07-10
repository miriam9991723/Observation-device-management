using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DalObject
{
    class DataSource
    {
        static internal List<ObservationDevice> devices = new List<ObservationDevice>();
        static internal int idIntilizer = 0;
        

        public static void intilize()
        {
            int numberOfDevices = 10;
            Random rand = new Random();
            int range;
            float fieldOfVision;
            DeviceType type;
            int id;
            for (int i = 0; i < numberOfDevices; i++)
            {
                id = idIntilizer;
                type = (DeviceType)(rand.Next() % 3);
                range = rand.Next()%50000;
                fieldOfVision = (float)rand.NextDouble()* 360;
                
                try
                {
                    devices.Add(new ObservationDevice(id, type, range, fieldOfVision));
                    idIntilizer++;
                }
                catch (Exception)
                {
                    i--;
                }

            }

        }
    }
}
