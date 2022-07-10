using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException(int id) : base($"Observation device:{id} is not found.") { }

    }
    public class RangeIsNotValid : Exception
    {
        public RangeIsNotValid() : base($"Range must be positive.") { }

    }
    public class FieldOfVisionNotValid : Exception
    {
        public FieldOfVisionNotValid() : base("Field of vision must be between 0 t0 360.") { }
    }
}
