using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ObservationDevice
    {
        public ObservationDevice(int id, DeviceType type, int range, float fieldOfVision)
        {
            Id = id;
            Type = type;
            Range = range;
            FieldOfVision = fieldOfVision;
        }

        public int Id { get; init; }
        public DeviceType Type { get; init; }

        private int range;
        public int Range
        {
            get
            {
                return range;
            }
            init
            {
                if (value < 0)
                    throw new DalApi.RangeIsNotValid();
                else range = value;
            }
        }

        private float fieldOfVision;
        public float FieldOfVision
        {
            get
            {
                return fieldOfVision;
            }
            init
            {
                if (value > 360 || value < 0)
                    throw new DalApi.FieldOfVisionNotValid();
                else fieldOfVision = value;
            }
        }


    }
}
